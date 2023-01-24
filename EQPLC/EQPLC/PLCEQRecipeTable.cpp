#include "StdAfx.h"
#include "PLCEQRecipeTable.h"

using namespace PLC;

CPLCEQRecipeTable::CPLCEQRecipeTable(void)
{
}

CPLCEQRecipeTable::~CPLCEQRecipeTable(void)
{
}

void CPLCEQRecipeTable::SetData(const char *szTagName, char *pData)
{
	int nIndex = 0;

	//	Flow Group
	memcpy(&m_nFlowGroup, &pData[nIndex], 20);
	nIndex += 20;

	//	EventID
	memcpy(&m_nEventID, &pData[nIndex], 2);
	nIndex += 2;

	//	Flow Recipe No.
	memcpy(&m_nFlowRecipeNo, &pData[nIndex], 2);
	nIndex += 2;

	IPLC::pPLCEvent->EventEQRecipeTable(GetPLCNo(), m_nEventID, m_nFlowRecipeNo, m_nFlowGroup);
}
