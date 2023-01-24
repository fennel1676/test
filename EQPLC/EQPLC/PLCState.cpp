#include "StdAfx.h"
#include "PLCState.h"

using namespace PLC;

CPLCState::CPLCState(void)
{
	m_nByWho = 0;

	for(int i = 0; i < 13; i++)
		m_nMasterAlarm[i] = 0;
}

CPLCState::~CPLCState(void)
{
}

void CPLCState::SetData(const char *szTagName, char *pData)//EQMSStatusDataPLCtoPC
{
	int nIndex = 0;

	char szBuf[8];
	int nMasterAlarm[13];

	//	PM Code
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 4);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_strPMCode = szBuf;
	m_strPMCode.TrimLeft(' ');
	m_strPMCode.TrimRight(' ');
	nIndex += 4;

	//	PAUSE Code
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 4);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_strPauseCode = szBuf;
	m_strPauseCode.TrimLeft(' ');
	m_strPauseCode.TrimRight(' ');
	nIndex += 4;


	//	ByWho
	memcpy(&m_nByWho, &pData[nIndex], 2);
	nIndex += 2;

	//Reserved_1
	nIndex += 2;

	//	Equipment Alarm Master

	//	Equipment Alarm PIO
	for(int i = 0; i < 13; i++)
	{
		memcpy(&nMasterAlarm[i], &pData[nIndex], 4);
		nIndex += 4;
	}


	//	Reserved_2 byte
	nIndex += 8;

	EventCommonState(m_strPMCode, m_strPauseCode, m_nByWho);
	EventMasterAlarm(nMasterAlarm);
}

void CPLCState::EventCommonState(CString &strPMCode, CString &strPauseCode, short nByWho)
{
	IPLC::pPLCEvent->EventCommonState(GetPLCNo(), strPMCode, strPauseCode, nByWho);
}

void CPLCState::EventMasterAlarm(int *pMasterAlarm)
{

	int nIndex;
	int i, j;
	int nSource, nDest;
	for(i = 0; i < 13; i++)
	{
		nIndex = 0x00000001;

		if(m_nMasterAlarm[i] == pMasterAlarm[i])	
			continue;

		for(j = 0; j < 32; j++)
		{
			nSource = m_nMasterAlarm[i] & nIndex;
			nDest = pMasterAlarm[i] & nIndex;
			if(nSource != nDest)
				IPLC::pPLCEvent->EventMasterAlarm(GetPLCNo(), i, j + 1, (0 != nDest) ? TRUE : FALSE);
			nIndex <<= 1;
		}

		m_nMasterAlarm[i] = pMasterAlarm[i];
	}

	//int nIndex;
	//int i, j;
	//int nSource, nDest;

	//nIndex = 0x00000001;

	//if(m_nMasterAlarm == nMasterAlarm)	return;

	//for(j = 0; j < 32; j++)
	//{
	//	nSource = m_nMasterAlarm & nIndex;
	//	nDest = nMasterAlarm & nIndex;
	//	if(nSource != nDest)
	//		IPLC::pPLCEvent->EventMasterAlarm(GetPLCNo(), 0, j + 1, (0 != nDest) ? TRUE : FALSE);
	//	nIndex <<= 1;
	//}

	//m_nMasterAlarm = nMasterAlarm;
}

