// EIP.cpp: implementation of the CEIP class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "EIP.h"
#include "ABConfig.h"

CEIP *CEIP::g_pEIP = NULL;

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CEIP::CEIP()
{
	m_pEIPEvent = NULL;
	memset(m_szHostIP, 0, sizeof(m_szHostIP));
	m_nRate = 0;
}

CEIP::CEIP(IEIPEvent *pIEIPEvent, char *szHostIP, int nRate)
{
	m_pEIPEvent = pIEIPEvent;
	SetHostIP(szHostIP);
	SetRate(nRate);
}

CEIP::~CEIP()
{
	delete m_pnLocalVarIds;
}

void CEIP::Init()
{
	TRACE("CEIP::Init()\n");

	CEIP::g_pEIP = this;
//	PropertyConfigurator::configure("log4cxx.lcf");

	//	Initializes internal structures with local variables/types based on the config file. 
	//	Returns 0 on success, or negative error code.
	//	Provided callback will be called any time a new value has been writen to a local variable, 
	//	either by class1 consumed connection or received class 3 unconnected message
	//	This function has to be called before any other.
	//	Function starts class1 connections, but it does not wait until all of them are established.

	int a = _SMPD_ProcessInitial(m_szHostIP, (char *) CABConfig::g_strConfig.operator LPCTSTR(), _DataChangeEvent, _StatusChangeEvent,(char *) CABConfig::g_strSMD.operator LPCTSTR());

	//m_nNoOfMirrors = 0;
	//m_bMirrorsActive = false;

	//	Returns number of all local tags/tables.
	m_nNoOfLocalVars = n_EtAdGetNumberOfAllVariables();
	m_pnLocalVarIds = (int*)malloc(m_nNoOfLocalVars * 4);

	//	Copies up to size variable ids into provided buffer.
	//	Returns number of variable ids copied into buff.
	int n = n_EtAdGetAllVariableIds(m_pnLocalVarIds, m_nNoOfLocalVars);
	if (n != m_nNoOfLocalVars)
	{
		TRACE(" failed to initialize all local variable ids expected=%d actual=%d\n", m_nNoOfLocalVars, n);
		m_nNoOfLocalVars = n;
	}
}

void CEIP::StatusChangeEvent(int nValID)
{
	TRACE("CEIP::StatusChangeEvent()\n");
	//	Returns TRUE if the variable is produced
	if (n_EtAdIsVariableProduced(nValID))
	{
		//	Returns number of open connections to a produced variable.
		//	Return 0 if variable is not produced, or -1 if there is no such variable.
		m_pEIPEvent->StatusEventProduced(nValID, n_EtAdIsVariableOnline(nValID));
	}
	//	Returns TRUE if the variable is consumed
	else if (n_EtAdIsVariableConsumed(nValID))
	{
		//	Returns TRUE if the variable is consumed and there is a live class1 connection.
		m_pEIPEvent->StatusEventConsumed(nValID, n_EtAdIsVariableOnline(nValID));
	}
}

void CEIP::DataChangeEvent(int nVarId)
{
	TRACE("CEIP::DataChangeEvent()\n");
	//	Returns name of the variable
	const char *szVarName = n_EtAdGetVariableName(nVarId);

	//	Returns number of variable elements. It is 1 for single valued, or array size for arrays.
	int nVarLength = n_EtAdGetVariableLength(nVarId);

	INT32 pData[125];
	memset(pData, 0x00, sizeof(INT32) * 125);
	//	Reads value(s) from an integer based SINT variable. 
	//	If variable is consumed the last received values from the producer are returned.
	//	If successful the function reads all variable elements up to the given size pl and returns number of elements read.
	
	// 해당 아이디에 대한 데이터 값을 pData에 가져온다
	int nLength = n_EtAdReadVariableDintValue(nVarId, (INT32*)pData, nVarLength);

	if (nLength < nVarLength)
	{
		TRACE("FAILED to read the whole variable length expected=%d actual=%d\n", nVarLength, nLength);
		nVarLength = nLength;
	}

	m_pEIPEvent->DataChangeEvent(szVarName, nVarId, (char*)pData);
}

void CEIP::_StatusChangeEvent(int nVarId)
{
	CEIP::g_pEIP->StatusChangeEvent(nVarId);
}

void CEIP::_DataChangeEvent(int nVarId)
{
	CEIP::g_pEIP->DataChangeEvent(nVarId);
}

BOOL CEIP::changeLocalVariable(int nValID, char* pData, int nLength)   // Bit시스널 체크 부분
{
	int len= n_EtAdWriteVariableDintValue(nValID, (int *) pData, nLength / 4);

	if (len == (nLength / 4))	return TRUE;
	else						return FALSE;

	return TRUE;
}

BOOL CEIP::changeUCMMVariable(char* ioAddress, char* varName, char* pData, int nLength)
{
	int len= n_EtAdSendVariableDintValue(ioAddress, varName, (int *) pData, nLength / 4);

	if (len == 0)	return TRUE;
	else						return FALSE;

	return TRUE;
}

void CEIP::changeLocalVariable(int nValID, int nIndex, int nValue)
{
	int index = nIndex;
	int varId = nValID;
	INT32 val = nValue;

	if (TRUE != hasVariableId(varId))
		printf(" first integer is not varid - out of the range\n");
	else
	{
		//	Returns number of variable elements. It is 1 for single valued, or array size for arrays.
		int varLen = n_EtAdGetVariableLength(varId);
		if (index < 0 || index >= varLen)
			printf(" second integer is not index - out of the range\n");
		else
		{
			//	Returns base type name for the given variable.
			//	Currently supported base types are: 
			//	DINT,INT,SINT,BOOL (4bytes, 2 bytes, 1 byte, 1 bit), REAL
			INT8 psint[500];
			int len = 0;

			memset(psint, 0x00, 500);
			//	Reads value(s) from an integer based SINT variable. 
			//	If variable is consumed the last received values from the producer are returned.
			//	If successful the function reads all variable elements up to the given size pl and returns number of elements read.
			len = n_EtAdReadVariableSintValue(varId, psint, varLen);
			if (len == varLen)
			{
				*(psint + index) = (INT8) (val & 0xff);
				//	Write given SINT values into variable elements. Returns number of actually written elements.
				//	If variable is produced values are copied into local buffer, and Class1 connection based on their transport types 
				//	transmits data to all consumers.
				//	NOTE: Writing to a local consumed variable will fail.
				len = n_EtAdWriteVariableSintValue(varId, psint, varLen);
				if (len == varLen)
					printf(" sucessfully changed value of the variable\n");
			}
		}
	}
}

BOOL CEIP::hasVariableId(int id)
{
	for (int i=0; i < m_nNoOfLocalVars; i++)
	{
		if (*(m_pnLocalVarIds + i) == id)
			return TRUE;
	}

	return FALSE;
}

BOOL CEIP::receiveValues(char *szSourceIOAddr, char *szRemoteValueName, int nVarID)
{
	CString str ="";

	if (TRUE == hasVariableId(nVarID))
	{
		//	Returns number of variable elements. It is 1 for single valued, or array size for arrays.
		int nVarLength = n_EtAdGetVariableLength(nVarID);
		const char *szVarName = n_EtAdGetVariableName(nVarID);

		//	Sends unconnected request to read a DINT based variable values from remote ethernet ip controller.
		//	ioAddress is IOAddress of the external controller
		//	varName is the name of the variable on the external controller.
		//	pl specifies the size of value buffer pv.
		//	If pl is smaller than real size of the array, only values up to the real size of the array will be received.
		//	Returns number of actually read elements.
		INT32 pData[125];
		memset(pData, 0x00, sizeof(INT32) * 125);

		int nLength = n_EtAdReceiveVariableDintValue(szSourceIOAddr, szRemoteValueName, (int *) pData, nVarLength);
		if (nLength > 0)
		{
			n_EtAdWriteVariableDintValue(nVarID, (int *) pData, nVarLength);
			m_pEIPEvent->DataChangeEvent(szVarName, nVarID, (char *) pData);
			return TRUE;
		}
		else
		{
			CUtil::WriteLogFile(_T("GlassData 길이로드 실패 : IP :%s, Name :%s, 길이 : %d, 결과 : %d"),szSourceIOAddr,szRemoteValueName,nVarLength,nLength);
		}
	}
	else
	{
		str.Format(_T("%d"),nVarID);
		CUtil::WriteLogFile(_T("GlassData 안에서 ValID 미 존재%s"),str);
	}
	return FALSE;
}

BOOL CEIP::receiveValues(char *szSourceIOAddr, char *szRemoteValueName, int nVarID, INT32 * pData, int nSize)
{
	if (TRUE == hasVariableId(nVarID))
	{
		//	Returns number of variable elements. It is 1 for single valued, or array size for arrays.
		int nVarLength = n_EtAdGetVariableLength(nVarID);
		const char *szVarName = n_EtAdGetVariableName(nVarID);

		//	Sends unconnected request to read a DINT based variable values from remote ethernet ip controller.
		//	ioAddress is IOAddress of the external controller
		//	varName is the name of the variable on the external controller.
		//	pl specifies the size of value buffer pv.
		//	If pl is smaller than real size of the array, only values up to the real size of the array will be received.
		//	Returns number of actually read elements.
		int nLength = n_EtAdReceiveVariableDintValue(szSourceIOAddr, szRemoteValueName, (INT32 *) pData, nSize);
		if (nLength > 0)
		{
			return TRUE;
		}
	}
	return FALSE;
}