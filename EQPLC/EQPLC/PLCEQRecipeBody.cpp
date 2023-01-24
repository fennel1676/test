#include "StdAfx.h"
#include "PLCEQRecipeBody.h"

using namespace PLC;

CPLCEQRecipeBody::CPLCEQRecipeBody(void)
{
	m_nFlowRecipeStartIndex = 0;
	for(int i = 0; i < 10; i++)
	{
		m_stFlowRecipeBody[i].nRevision = 0;
		m_stFlowRecipeBody[i].nYear = 0;
		m_stFlowRecipeBody[i].nMonth = 0;
		m_stFlowRecipeBody[i].nDay = 0;
		m_stFlowRecipeBody[i].nHour = 0;
		m_stFlowRecipeBody[i].nMinute = 0;
		m_stFlowRecipeBody[i].nSecond = 0;
		memset(&m_stFlowRecipeBody[i].nFlowBody, 0x00, 20);
	}
}

CPLCEQRecipeBody::~CPLCEQRecipeBody(void)
{
}

void CPLCEQRecipeBody::SetData(const char *szTagName, char *pData)
{
	int nIndex = 0;

	char szBuf[8];
	CString strBuf;

	for(int i = 0; i < 10; i++)
	{
		//	FlowID
		memset(szBuf, 0x00, sizeof(szBuf));
		memcpy(szBuf, &pData[nIndex], 4);
		CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
		strBuf = szBuf;
		strBuf.TrimLeft(' ');
		strBuf.TrimRight(' ');
		strcpy(m_stFlowRecipeBody[i].szFlowID, strBuf.operator LPCTSTR());
		nIndex += 4;

		//	Revision
		memcpy(&m_stFlowRecipeBody[i].nRevision, &pData[nIndex], 2);
		nIndex += 2;

		//	Year
		memcpy(&m_stFlowRecipeBody[i].nYear, &pData[nIndex], 2);
		nIndex += 2;

		//	Month
		memcpy(&m_stFlowRecipeBody[i].nMonth, &pData[nIndex], 2);
		nIndex += 2;

		//	Day
		memcpy(&m_stFlowRecipeBody[i].nDay, &pData[nIndex], 2);
		nIndex += 2;

		//	Hour
		memcpy(&m_stFlowRecipeBody[i].nHour, &pData[nIndex], 2);
		nIndex += 2;

		//	Minute
		memcpy(&m_stFlowRecipeBody[i].nMinute, &pData[nIndex], 2);
		nIndex += 2;

		//	Second
		memcpy(&m_stFlowRecipeBody[i].nSecond, &pData[nIndex], 2);
		nIndex += 2;

		//	Flow Body
		memcpy(&m_stFlowRecipeBody[i].nFlowBody, &pData[nIndex], 20);
		nIndex += 20;

		//	reserved
		nIndex += 2;
	}

	IPLC::pPLCEvent->EventEQRecipeBody(GetPLCNo(), m_nFlowRecipeStartIndex, m_stFlowRecipeBody);
}

void CPLCEQRecipeBody::SetTagName(CString strTagName)
{
	IPLC::SetTagName(strTagName);

	CString strPLCNo;
	AfxExtractSubString(strPLCNo, strTagName, 1, '_');
	int nPLCNo = atoi(strPLCNo.operator LPCTSTR());

	int nUnitNo = 0;
	if(0 == strTagName.Compare("C_01_EQPFlowRecipeTable1to10"))				m_nFlowRecipeStartIndex = 1;
	else if(0 == strTagName.Compare("C_01_EQPFlowRecipeTable11to20"))		m_nFlowRecipeStartIndex = 11;
	else if(0 == strTagName.Compare("C_01_EQPFlowRecipeTable21to30"))		m_nFlowRecipeStartIndex = 21;
	else if(0 == strTagName.Compare("C_01_EQPFlowRecipeTable31to40"))		m_nFlowRecipeStartIndex = 31;
	else if(0 == strTagName.Compare("C_01_EQPFlowRecipeTable41to50"))		m_nFlowRecipeStartIndex = 41;
	else if(0 == strTagName.Compare("C_01_EQPFlowRecipeTable51to60"))		m_nFlowRecipeStartIndex = 51;
	else if(0 == strTagName.Compare("C_01_EQPFlowRecipeTable61to70"))		m_nFlowRecipeStartIndex = 61;

	else if(0 == strTagName.Compare("C_02_EQPFlowRecipeTable1to10"))		m_nFlowRecipeStartIndex = 1;
	else if(0 == strTagName.Compare("C_02_EQPFlowRecipeTable11to20"))		m_nFlowRecipeStartIndex = 11;
	else if(0 == strTagName.Compare("C_02_EQPFlowRecipeTable21to30"))		m_nFlowRecipeStartIndex = 21;
	else if(0 == strTagName.Compare("C_02_EQPFlowRecipeTable31to40"))		m_nFlowRecipeStartIndex = 31;
	else if(0 == strTagName.Compare("C_02_EQPFlowRecipeTable41to50"))		m_nFlowRecipeStartIndex = 41;
	else if(0 == strTagName.Compare("C_02_EQPFlowRecipeTable51to60"))		m_nFlowRecipeStartIndex = 51;
	else if(0 == strTagName.Compare("C_02_EQPFlowRecipeTable61to70"))		m_nFlowRecipeStartIndex = 61;
}
