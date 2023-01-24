// EIP.h: interface for the CEIP class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_EIP_H__1A5946F7_FE39_4339_A9BB_5C4E40254C67__INCLUDED_)
#define AFX_EIP_H__1A5946F7_FE39_4339_A9BB_5C4E40254C67__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#pragma warning(push)
#pragma warning(disable : 4786)
#include <vector>
#include <algorithm>
#pragma warning(pop) 
using namespace std;

#include "IEIPEvent.h"
#include "./INC/Define.h"
#include "./INC/Interface.h"

class CEIP
{
public:
	CEIP();
	CEIP(IEIPEvent *pIEIPEvent, char *szHostIP, int nRate);
	virtual ~CEIP();

public:
	void Init();
	static void _StatusChangeEvent(int nVarId);
	static void _DataChangeEvent(int nVarId);
	void StatusChangeEvent(int nVarId);
	void DataChangeEvent(int nVarId);
	// Class1
	BOOL changeLocalVariable(int nValID, char* pData, int nLength);
	void changeLocalVariable(int nValID, int nIndex, int nValue);
	BOOL changeUCMMVariable(char* ioAddress, char* varName, char* pData, int nLength);
	BOOL hasVariableId(int id);
	// UCMM
	BOOL receiveValues(char *szSourceIOAddr, char *szRemoteValueName, int nVarID);
	BOOL receiveValues(char *szSourceIOAddr, char *szRemoteValueName, int nVarID, INT32 *pData, int nSize);

public:
	static CEIP *g_pEIP;
	void SetEventParent(IEIPEvent *pIEIPEvent)	{m_pEIPEvent = pIEIPEvent;}
	IEIPEvent *GetEventParent()					{return m_pEIPEvent;}
	void SetHostIP(char *szHostIP)				{strcpy(m_szHostIP, szHostIP);}
	char* GetHostIP()							{return m_szHostIP;}
	void SetRate(int nRate)						{m_nRate = nRate;}
	int	GetRate()								{return m_nRate;}
	int GetTagNum()								{return m_nNoOfLocalVars;}
	const char * GetTagName(int nVarID)			{return n_EtAdGetVariableName(nVarID);}

private:
	IEIPEvent *m_pEIPEvent;
	
	char m_szHostIP[17];
	int m_nRate;
	int m_nNoOfLocalVars;
	int *m_pnLocalVarIds;

	//int m_nListLevel; // 0: all update 
	//bool m_bDisableUpdates;

	//int m_nNoOfMirrors;
	//int m_nConsumedVarIds[10];
	//int m_nConsumedIndeces[10];
	//int m_nProducedVarIds[10];
	//int m_nVarLengths[10];
	//int m_nMirrorLimits[10];
	//bool m_bMirrorsActive;
};

#endif // !defined(AFX_EIP_H__1A5946F7_FE39_4339_A9BB_5C4E40254C67__INCLUDED_)
