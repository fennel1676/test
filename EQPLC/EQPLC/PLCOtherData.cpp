#include "StdAfx.h"
#include "PLCOtherData.h"

using namespace PLC;

CPLCOtherData::CPLCOtherData(void)
{
	memset(&m_stEQOnlineParam, 0x00, sizeof(EQ_ONLINE_PARAM));
	memset(m_stECIDInfo, 0x00, sizeof(ECID_INFO) * 14);
	memset(m_stManualDispatchRule, 0x00, sizeof(MANUAL_DISPATCH_RULE) * 5);
}

CPLCOtherData::~CPLCOtherData(void)
{
}

void CPLCOtherData::SetData(const char *szTagName, char *pData)
{
	int nIndex = 0;

	EventEQOnlineParam(pData, nIndex);
	EventECIDInfo(pData, nIndex);
	EventManualDispatchRule(pData, nIndex);
}

void CPLCOtherData::EventEQOnlineParam( char *pData, int &nIndex)
{
	//	Event ID
	memcpy(&m_stEQOnlineParam.nEventID, &pData[nIndex], 2);
	nIndex += 2;

	//	Judgement
	memcpy(&m_stEQOnlineParam.nJudgement, &pData[nIndex], 2);
	nIndex += 2;

	//	VCR Mode #01
	memcpy(&m_stEQOnlineParam.nVCRMode[0], &pData[nIndex], 2);
	nIndex += 2;

	//	Wait Time For Glass ID Key Input #01
	memcpy(&m_stEQOnlineParam.nWaitTime[0], &pData[nIndex], 2);
	nIndex += 2;

	//	VCR Mode #02
	memcpy(&m_stEQOnlineParam.nVCRMode[1], &pData[nIndex], 2);
	nIndex += 2;

	//	Wait Time For Glass ID Key Input #02
	memcpy(&m_stEQOnlineParam.nWaitTime[1], &pData[nIndex], 2);
	nIndex += 2;

	//	VCR Mode #03
	memcpy(&m_stEQOnlineParam.nVCRMode[2], &pData[nIndex], 2);
	nIndex += 2;

	//	Wait Time For Glass ID Key Input #03
	memcpy(&m_stEQOnlineParam.nWaitTime[2], &pData[nIndex], 2);
	nIndex += 2;

	//	VCR Mode #04
	memcpy(&m_stEQOnlineParam.nVCRMode[3], &pData[nIndex], 2);
	nIndex += 2;

	//	Wait Time For Glass ID Key Input #04
	memcpy(&m_stEQOnlineParam.nWaitTime[3], &pData[nIndex], 2);
	nIndex += 2;

	//	VCR Mode #05
	memcpy(&m_stEQOnlineParam.nVCRMode[4], &pData[nIndex], 2);
	nIndex += 2;

	//	Wait Time For Glass ID Key Input #05
	memcpy(&m_stEQOnlineParam.nWaitTime[4], &pData[nIndex], 2);
	nIndex += 2;

	//	Propriety wipqty mode
	memcpy(&m_stEQOnlineParam.nWIPQTYMode, &pData[nIndex], 2);
	nIndex += 2;

	//	ByWho
	memcpy(&m_stEQOnlineParam.nByWho, &pData[nIndex], 2);
	nIndex += 2;

	//	reserved
	nIndex += 4;

	IPLC::pPLCEvent->EventEQOnlineParam(GetPLCNo(), &m_stEQOnlineParam);
}

void CPLCOtherData::EventECIDInfo(char *pData, int &nIndex)
{
	for(int i = 0; i < 14; i++)
	{
		//	ECID
		memcpy(&m_stECIDInfo[i].nECID, &pData[nIndex], 2);
		nIndex += 2;

		//	reserved
		nIndex += 2;

		//	ECDEF
		memcpy(&m_stECIDInfo[i].nECDE, &pData[nIndex], 2);
		nIndex += 2;

		//	ECSLL
		memcpy(&m_stECIDInfo[i].nECSLL, &pData[nIndex], 2);
		nIndex += 2;

		//	ECSUL
		memcpy(&m_stECIDInfo[i].nECSUL, &pData[nIndex], 2);
		nIndex += 2;

		//	ECWLL
		memcpy(&m_stECIDInfo[i].nECWLL, &pData[nIndex], 2);
		nIndex += 2;

		//	ECWUL
		memcpy(&m_stECIDInfo[i].nECWUL, &pData[nIndex], 2);
		nIndex += 2;
	}

	IPLC::pPLCEvent->EventECIDInfo(GetPLCNo(), m_stECIDInfo);
}

void CPLCOtherData::EventManualDispatchRule(char *pData, int &nIndex)
{
	char szBuf[24];
	CString strBuf;
	for(int i = 0; i < 5; i++)
	{
		//	UnitNo
		memcpy(&m_stManualDispatchRule[i].nUnitNo, &pData[nIndex], 2);
		nIndex += 2;

		//	DISPATCH OPTION
		memcpy(&m_stManualDispatchRule[i].nDispatchOption, &pData[nIndex], 2);
		nIndex += 2;

		//	DeviceID
		memset(szBuf, 0x00, sizeof(szBuf));
		memcpy(szBuf, &pData[nIndex], 20);
		CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
		strBuf = szBuf;
		strBuf.TrimLeft(' ');
		strBuf.TrimRight(' ');
		strcpy(m_stManualDispatchRule[i].szDeviceID, strBuf.operator LPCTSTR());
		nIndex += 20;

		//	RUNLINE
		memcpy(&m_stManualDispatchRule[i].nRunLine, &pData[nIndex], 2);
		nIndex += 2;

		//	reserved
		nIndex += 2;

		//	TARGET
		memcpy(&m_stManualDispatchRule[i].nTarget, &pData[nIndex], 4);
		nIndex += 4;
	}

	IPLC::pPLCEvent->EventManualDispatchRule(GetPLCNo(), m_stManualDispatchRule);
}
