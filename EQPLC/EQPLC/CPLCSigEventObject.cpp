#include "StdAfx.h"
#include "CPLCSigEventObject.h"
#include "CPLCEventObjectUnit.h"
#include "Util.h"

using namespace PLC;

CPLCSigEventObject::CPLCSigEventObject(void)
{
	//m_nEventID=0;
	//m_strPortID="";
	//m_nPortState=0;
	//m_nPortType=0;
	//m_strPortMode="";
	//m_nSortType=0;
	//m_nCSTDemand=0;
	//m_strCSTID="";
	//m_strCSTType="";
	//m_strMat_Stif="";
	//m_strCur_Stif="";
	//m_nBatch_Order=0;
	//m_nByWho=0;
	//m_nReply=0;
	//SetPortNo(1);
}

CPLCSigEventObject::~CPLCSigEventObject(void)
{
}

void CPLCSigEventObject::SetData(char *pData, int &nIndex)
{
	PLC::PortInfoItem strPortInfoItem;

	char szBuf[256];

	//	EventID
	strPortInfoItem.m_nEventID = 0;
	memcpy(&strPortInfoItem.m_nEventID, &pData[nIndex], 2);
	nIndex += 2;

	// ByWho
	strPortInfoItem.m_nByWho=0;
	memcpy(&strPortInfoItem.m_nByWho, &pData[nIndex], 2);
	nIndex += 2;

	// PortID
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 4);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	strPortInfoItem.m_strPortID = szBuf;
	strPortInfoItem.m_strPortID.TrimLeft(' ');
	strPortInfoItem.m_strPortID.TrimRight(' ');
	nIndex += 4;

	// PortState
	strPortInfoItem.m_nPortState=0;
	memcpy(&strPortInfoItem.m_nPortState, &pData[nIndex], 2);
	nIndex += 2;

	// PortType
	strPortInfoItem.m_nPortType=0;
	memcpy(&strPortInfoItem.m_nPortType, &pData[nIndex], 2);
	nIndex += 2;

	// PortMode
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 2);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	strPortInfoItem.m_strPortMode = szBuf;
	strPortInfoItem.m_strPortMode.TrimLeft(' ');
	strPortInfoItem.m_strPortMode.TrimRight(' ');
	nIndex += 2;

	// SortType
	strPortInfoItem.m_nSortType=0;
	memcpy(&strPortInfoItem.m_nSortType, &pData[nIndex], 2);
	nIndex += 2;

	// CSTDemand
	strPortInfoItem.m_nCSTDemand=0;
	memcpy(&strPortInfoItem.m_nCSTDemand, &pData[nIndex], 2);
	nIndex += 2;

	// RESERVED
	nIndex += 2;

	// CSTID
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 16);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	strPortInfoItem.m_strCSTID = szBuf;
	//strPortInfoItem.m_strCSTID.TrimLeft(' ');
	strPortInfoItem.m_strCSTID.TrimRight();
	nIndex += 16;

	// CSTType
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 4);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	strPortInfoItem.m_strCSTType = szBuf;
	strPortInfoItem.m_strCSTType.TrimLeft(' ');
	strPortInfoItem.m_strCSTType.TrimRight(' ');
	nIndex += 4;

	// Mat_Stif
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 4);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	strPortInfoItem.m_strMat_Stif = szBuf;
	strPortInfoItem.m_strMat_Stif.TrimLeft(' ');
	strPortInfoItem.m_strMat_Stif.TrimRight(' ');
	nIndex += 4;

	// Cur_Stif
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 4);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	strPortInfoItem.m_strCur_Stif = szBuf;
	strPortInfoItem.m_strCur_Stif.TrimLeft(' ');
	strPortInfoItem.m_strCur_Stif.TrimRight(' ');
	nIndex += 4;

	// Batch_Order
	strPortInfoItem.m_nBatch_Order=0;
	memcpy(&strPortInfoItem.m_nBatch_Order, &pData[nIndex], 2);
	nIndex += 2;

	//Reply
	strPortInfoItem.m_nReply=0;
	memcpy(&strPortInfoItem.m_nReply, &pData[nIndex], 2);
	nIndex += 2;

	if(CPLCEventObjectUnit::m_bInitPort == TRUE)
	{
		IPLC::pPLCEvent->EventPort(m_nPLCNo, strPortInfoItem, m_nPortNo);
		CPLCEventObjectUnit::m_nInitCount++;
		if(CPLCEventObjectUnit::m_nInitCount == 4)
		{
			CPLCEventObjectUnit::m_bInitPort = FALSE;
			CPLCEventObjectUnit::m_nInitCount = 0;
		}
	}
	else
	{
		if(0 == strPortInfoItem.m_nEventID && 0 == strPortInfoItem.m_nPortState
			&& "" == strPortInfoItem.m_strMat_Stif
			&& "" == strPortInfoItem.m_strCur_Stif)
			return;
		if(m_strPortInfoItem.m_nEventID != strPortInfoItem.m_nEventID
			|| m_strPortInfoItem.m_nPortState != strPortInfoItem.m_nPortState
			|| m_strPortInfoItem.m_strMat_Stif != strPortInfoItem.m_strMat_Stif
			|| m_strPortInfoItem.m_strCur_Stif != strPortInfoItem.m_strCur_Stif
			|| strPortInfoItem.m_nReply != 0)
			IPLC::pPLCEvent->EventPort(m_nPLCNo, strPortInfoItem, m_nPortNo);
	}
	m_strPortInfoItem.m_nEventID = strPortInfoItem.m_nEventID;
	m_strPortInfoItem.m_nPortState = strPortInfoItem.m_nPortState;
	m_strPortInfoItem.m_strMat_Stif = strPortInfoItem.m_strMat_Stif;
	m_strPortInfoItem.m_strCur_Stif = strPortInfoItem.m_strCur_Stif;
}