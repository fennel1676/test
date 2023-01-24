// IEIPEvent.h: interface for the IEIPEvent class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_IEIPEVENT_H__5C400C6D_49D8_4480_A7A1_8901B24E6268__INCLUDED_)
#define AFX_IEIPEVENT_H__5C400C6D_49D8_4480_A7A1_8901B24E6268__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

interface IEIPEvent  
{
	virtual void StatusEventProduced(int nVarId, int nConnections) = 0;
	virtual void StatusEventConsumed(int nVarId, BOOL bOnline) = 0;
	virtual void DataChangeEvent(const char *szTagName, int nVarID, char *pData) = 0;
};

#endif // !defined(AFX_IEIPEVENT_H__5C400C6D_49D8_4480_A7A1_8901B24E6268__INCLUDED_)
