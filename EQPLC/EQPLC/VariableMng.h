// VariableMng.h: interface for the CVariableMng class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_VARIABLEMNG_H__7DA5CFAB_78E5_4457_A985_AE65A12CD77C__INCLUDED_)
#define AFX_VARIABLEMNG_H__7DA5CFAB_78E5_4457_A985_AE65A12CD77C__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#pragma warning(push)
#pragma warning(disable : 4786)
#include <vector>
#include <algorithm>
#pragma warning(pop) 
using namespace std;

#include "Variable.h"

class CVariableMng  
{
public:
	CVariableMng();
	virtual ~CVariableMng();

public:
	BOOL Load(const char *szPath);
	CVariable *GetVariable(const char *szTagName);
	int GetID(const char *szTagName);

private:
	CString m_strPath;
	vector<CVariable *> m_vtVariables;
};

#endif // !defined(AFX_VARIABLEMNG_H__7DA5CFAB_78E5_4457_A985_AE65A12CD77C__INCLUDED_)
