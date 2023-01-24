// Variable.h: interface for the CVariable class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_VARIABLE_H__7D4AC2AE_E6D9_4535_90AE_75DA5D302332__INCLUDED_)
#define AFX_VARIABLE_H__7D4AC2AE_E6D9_4535_90AE_75DA5D302332__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class CVariable  
{
public:
	CVariable();
	virtual ~CVariable();

public:
	inline void SetTagName(const char * szTagName)		{m_strTagName = szTagName;}		
	inline CString &GetTagName()	{return m_strTagName;}
	inline void SetTypeName(const char * szTypeName)	{m_strTypeName = szTypeName;}		
	inline CString &GetTypeName()	{return m_strTypeName;}
	inline char * GetBuffer()		{return m_pData;}

private:
	CString m_strTagName;
	CString m_strTypeName;
	char m_pData[500];
};

#endif // !defined(AFX_VARIABLE_H__7D4AC2AE_E6D9_4535_90AE_75DA5D302332__INCLUDED_)
