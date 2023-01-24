#include "StdAfx.h"
#include "CPLCEventObjectUnit.h"
using namespace PLC;
BOOL CPLCEventObjectUnit::m_bInitPort = FALSE;
short CPLCEventObjectUnit::m_nInitCount = 0;

CPLCEventObjectUnit::CPLCEventObjectUnit(void)
{
}

CPLCEventObjectUnit::~CPLCEventObjectUnit(void)
{
}

void CPLCEventObjectUnit::SetTagName(CString strTagName)
{
	IPLC::SetTagName(strTagName);

	CString strPLCNo;
	AfxExtractSubString(strPLCNo, strTagName, 1, '_');
	int nPLCNo = atoi(strPLCNo.operator LPCTSTR());

	int nPortNo = 1;
	int nIndex = 0;

	for(int i = 0; i < 4; i++)
	{
		m_objPLCEventUnit[i].SetPortNo(nPortNo + i);
		m_objPLCEventUnit[i].SetPLCNo(nPLCNo - 1);
	}
}

void CPLCEventObjectUnit::SetData(const char *szTagName, char *pData)
{
	int nIndex = 0;
	for(int i = 0; i < 4; i++)
	{
		m_objPLCEventUnit[i].SetData(pData, nIndex);
	}
}
