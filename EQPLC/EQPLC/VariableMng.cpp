// VariableMng.cpp: implementation of the CVariableMng class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "VariableMng.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CVariableMng::CVariableMng()
{

}

CVariableMng::~CVariableMng()
{

}

BOOL CVariableMng::Load(const char *szPath)
{
	CVariable *pVariable = NULL;
	pVariable = new CVariable;
	pVariable->SetTagName("C_TransferGlassDataUnit1");
	pVariable->SetTypeName("uGlassTransferDataPLCtoPC");
	m_vtVariables.push_back(pVariable);
	pVariable = new CVariable;
	pVariable->SetTagName("bbb");
	pVariable->SetTypeName("uGlassTransferDataPLCtoPC");
	m_vtVariables.push_back(pVariable);

	return TRUE;
}

CVariable *CVariableMng::GetVariable(const char *szTagName)
{
	vector<CVariable *>::iterator itPos;
	CVariable *pVariable = NULL;
	for(itPos = m_vtVariables.begin(); itPos != m_vtVariables.end(); itPos++)
	{
		pVariable = (*itPos);
		if(0 == pVariable->GetTagName().Compare(szTagName))
			return pVariable;
	}
	return NULL;
}

int CVariableMng::GetID(const char *szTagName)
{
	CVariable *pVariable = NULL;
	for(int i = 0; i < m_vtVariables.size(); i++)
	{
		pVariable = m_vtVariables[i];
		if(0 == pVariable->GetTagName().Compare(szTagName))
			return i;
	}
	return -1;
}
