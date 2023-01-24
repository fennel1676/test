#pragma once

#include "IPLC.h"

namespace PLC
{
class CPLCStateUnit	
{
public:
	CPLCStateUnit(void);
	virtual ~CPLCStateUnit(void);

public:
	void SetPLCNo(int nPLCNo)						{m_nPLCNo = nPLCNo;}
	void SetUnitNo(int nUnitNo)						{m_nUnitNo = nUnitNo;}
	void SetData(char *pData, int &nIndex);
	void SetOut(int nOut)							{m_nOut = nOut;}

	int GetUnitNo()									{return m_nUnitNo;}

protected:
	void EventState(int nEQnProcessStatus, short nByWhoEQ, short nByWhoProcess);
	void EventAlarm(int nUnitAlarm);
	void EventPanel(int nEventID, CString &strHPanelID, CString strBrokenCode);
	void EventHSSignal(int nHSSignalBits, CString &strRefuseCode, short nRefuseBit);
	void EventGlassDataReq(int nPanelExist);

private:
	int m_nUnitNo;
	int m_nPLCNo;
	int m_nOut;

	int m_nEQnProcessStatus;
	int m_nUnitAlarm;
	int m_nEventID;
	CString m_strHPanelID;
	short m_nByWhoEQ;
	short m_nByWhoProcess;
	CString m_strBrokenCode;
	int m_nPanelExist;
	CString m_strRefuseCode;
	short m_nRefuseBit;
	int m_nHSSignalBits;
};
}
