#include "StdAfx.h"
#include "PLCStateUnit.h"
#include "ABConfig.h"
#include "Util.h"

using namespace PLC;

CPLCStateUnit::CPLCStateUnit(void)
{
	m_nEQnProcessStatus = 0;
	m_nUnitAlarm = 0;
	m_nEventID = 0;
	m_nByWhoEQ = 0;
	m_nByWhoProcess = 0;
	m_strBrokenCode = "";
	m_nHSSignalBits = 0;
	m_nPanelExist = 0;
	SetUnitNo(1);
}

CPLCStateUnit::~CPLCStateUnit(void)
{
}

void CPLCStateUnit::SetData(char *pData, int &nIndex)
{
	char szBuf[16];

	int nEQnProcessStatus, nUnitAlarm, nEventID;
	CString strHPanelID, strRefuseCode;
	short nByWhoEQ, nByWhoProcess, nPanelExist, nRefuseBit;
	int nHSSignalBits;
	CString strBrokenCode;

	//	EQ & Process Status / Panel Exist
	memcpy(&nEQnProcessStatus, &pData[nIndex], 4);
	nIndex += 4;

	//	Unit Alarm
	memcpy(&nUnitAlarm, &pData[nIndex], 4);
	nIndex += 4;

	//	Event ID
	memcpy(&nEventID, &pData[nIndex], 4);
	nIndex += 4;

	//	H_PANELID
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 12);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	strHPanelID = szBuf;
	strHPanelID.TrimLeft(' ');
	strHPanelID.TrimRight(' ');
	nIndex += 12;

	//	EQ ByWho
	memcpy(&nByWhoEQ, &pData[nIndex], 2);
	nIndex += 2;

	//	Process ByWho
	memcpy(&nByWhoProcess, &pData[nIndex], 2);
	nIndex += 2;

	//	Broken Code
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 4);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	strBrokenCode = szBuf;
	strBrokenCode.TrimLeft(' ');
	strBrokenCode.TrimRight(' ');
	nIndex += 4;

	//	Panel Exist
	memcpy(&nPanelExist, &pData[nIndex], 2);
	nIndex += 2;

	//	reserved
	nIndex += 2;

	//	Refuse Code
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 2);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	strRefuseCode = szBuf;
	strRefuseCode.TrimLeft(' ');
	strRefuseCode.TrimRight(' ');
	nIndex += 2;

	//	Refuse Bit
	memcpy(&nRefuseBit, &pData[nIndex], 2);
	nIndex += 2;

	//	H/S Signal Bits Signal Table By Unit
	memcpy(&nHSSignalBits, &pData[nIndex], 4);
	nIndex += 4;

	EventAlarm(nUnitAlarm);
	EventState(nEQnProcessStatus, nByWhoEQ, nByWhoProcess);
	EventPanel(nEventID, strHPanelID, strBrokenCode);
	//EventGlassDataReq(nPanelExist);
	EventHSSignal(nHSSignalBits, strRefuseCode, nRefuseBit);
}

void CPLCStateUnit::EventState(int nEQnProcessStatus, short nByWhoEQ, short nByWhoProcess)
{
	if(m_nEQnProcessStatus != nEQnProcessStatus)
	{   // CDlg로 넘어가 함수 호출
		IPLC::pPLCEvent->EventState(m_nPLCNo, m_nUnitNo, nEQnProcessStatus, nByWhoEQ, nByWhoProcess);
		m_nEQnProcessStatus = nEQnProcessStatus;
	}
}

void CPLCStateUnit::EventAlarm(int nUnitAlarm)
{
	if(m_nUnitAlarm == nUnitAlarm)	
		return;

	int nIndex = 0x00000001;
	int nSource, nDest;
	for(int i = 0; i < 32; i++)
	{
		nSource = m_nUnitAlarm & nIndex;
		nDest = nUnitAlarm & nIndex;
		if(nSource != nDest)
			IPLC::pPLCEvent->EventUnitAlarm(m_nPLCNo, m_nUnitNo, i + 1, (0 != nDest) ? TRUE : FALSE);
		nIndex <<= 1;
	}
	m_nUnitAlarm = nUnitAlarm;
}

void CPLCStateUnit::EventPanel(int nEventID, CString &strHPanelID, CString strBrokenCode)
{
	if(m_nEventID == nEventID && (0 == m_strHPanelID.Compare(strHPanelID)))
	{
		return;
	}

	// Panel Start for Indexer
	int nComp6D = nEventID & 0x01;
	int nComp6S = m_nEventID & 0x01;

	// Panel End for Indexer
	int nComp7D = nEventID & 0x02;
	int nComp7S = m_nEventID & 0x02;

	// Glass Broken
	int nComp14D = nEventID & 0x04;
	int nComp14S = m_nEventID & 0x04;

	// Glass Unbroken
	int nComp15D = nEventID & 0x08;
	int nComp15S = m_nEventID & 0x08;

	// Process Start(In) for Unit
	int nComp16D = nEventID & 0x10;
	int nComp16S = m_nEventID & 0x10;

	// Process End(Out) for Unit
	int nComp17D = nEventID & 0x20;
	int nComp17S = m_nEventID & 0x20;

	//	Start / IN / Unbroken
	if(((0x01 == nComp6D && nComp6S != nComp6D) ||
		(0x08 == nComp15D && nComp15S != nComp15D) || 
		(0x10 == nComp16D && nComp16S != nComp16D)))
	{
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("UnitState Infomation - UnitNo : %d, GlassIn"), m_nUnitNo);
		IPLC::pPLCEvent->EventGlassDataReq(m_nPLCNo, m_nUnitNo);
	}

	//	Broken / OUT
	if(	(0x04 == nComp14D && nComp14S != nComp14D))
	{
			IPLC::pPLCEvent->EventPanel(m_nPLCNo, m_nUnitNo, nEventID, strHPanelID, strBrokenCode);
	}
	if((0x20 == nComp17D && nComp17S != nComp17D))
	{
		if(m_nUnitNo == 11 || m_nUnitNo == 12 || m_nUnitNo == 13 || m_nUnitNo == 14)
		{
			IPLC::pPLCEvent->EventPanel(m_nPLCNo, m_nUnitNo, nEventID, strHPanelID, strBrokenCode);
		}
	}

	m_nEventID = nEventID;
	m_strHPanelID = strHPanelID;
	m_strBrokenCode = strBrokenCode;
}

void CPLCStateUnit::EventGlassDataReq(int nPanelExist)
{
	if(m_nPanelExist != nPanelExist)
		IPLC::pPLCEvent->EventGlassDataReq(m_nPLCNo, m_nUnitNo);

	m_nPanelExist = nPanelExist;
}

void CPLCStateUnit::EventHSSignal(int nHSSignalBits, CString &strRefuseCode, short nRefuseBit)
{
	if(m_nHSSignalBits == nHSSignalBits)	return;

	int nIndex = 0x00000001;
	int nSource, nDest;
	for(int i = 0; i < 32; i++)
	{
		nSource = m_nHSSignalBits & nIndex;
		nDest = nHSSignalBits & nIndex;
		if(nSource != nDest)
			IPLC::pPLCEvent->EventHSSignal(m_nPLCNo, m_nUnitNo, i + 1, strRefuseCode, nRefuseBit, (0 != nDest) ? TRUE : FALSE);
		nIndex <<= 1;
	}
	m_nHSSignalBits = nHSSignalBits;
}
