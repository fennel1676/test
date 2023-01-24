#include "StdAfx.h"
#include "PLCStateUnitGroup.h"

using namespace PLC;

CPLCStateUnitGroup::CPLCStateUnitGroup(void)
{
}

CPLCStateUnitGroup::~CPLCStateUnitGroup(void)
{
}

void CPLCStateUnitGroup::SetTagName(CString strTagName)
{
	IPLC::SetTagName(strTagName);

	CString strPLCNo;
	AfxExtractSubString(strPLCNo, strTagName, 1, '_');
	int nPLCNo = atoi(strPLCNo.operator LPCTSTR());

	int nUnitNo = 0;
	if(0 == strTagName.Compare("C_01_EQStateUnit1to10"))			nUnitNo = 1;
	else if(0 == strTagName.Compare("C_01_EQStateUnit11to20"))		nUnitNo = 11;
	else if(0 == strTagName.Compare("C_01_EQStateUnit21to30"))		nUnitNo = 21;
	else if(0 == strTagName.Compare("C_01_EQStateUnit31to40"))		nUnitNo = 31;
	else if(0 == strTagName.Compare("C_01_EQStateUnit41to50"))		nUnitNo = 41;
	else if(0 == strTagName.Compare("C_01_EQStateUnit51to60"))		nUnitNo = 51;
	else if(0 == strTagName.Compare("C_01_EQStateUnit61to70"))		nUnitNo = 61;
	else if(0 == strTagName.Compare("C_01_EQStateUnit71to80"))		nUnitNo = 71;
	else if(0 == strTagName.Compare("C_01_EQStateUnit81to90"))		nUnitNo = 81;

	int nIndex = 0;
	for(int i = 0; i < 10; i++)
	{
		m_objPLCStateUnit[i].SetUnitNo(nUnitNo + i);
		m_objPLCStateUnit[i].SetPLCNo(nPLCNo - 1);
	}
}

void CPLCStateUnitGroup::SetData(const char *szTagName, char *pData)
{
	int nIndex = 0;
	for(int i = 0; i < 10; i++)
	{
		m_objPLCStateUnit[i].SetData(pData, nIndex);
	}
}
