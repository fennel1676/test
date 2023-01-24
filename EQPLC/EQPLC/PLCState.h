#pragma once

#include "IPLC.h"

namespace PLC
{
	class CPLCState : public IPLC
	{
	public:
		CPLCState(void);
		virtual ~CPLCState(void);

	public:
		virtual void SetData(const char *szTagName, char *pData);
		CString &GetPMCode()		{return m_strPMCode;}
		CString &GetPauseCode()		{return m_strPauseCode;}
		short GetByWho()			{return m_nByWho;}

	protected:
		void EventCommonState(CString &strPMCode, CString &strPauseCode, short nByWho);
		void EventMasterAlarm(int *pMasterAlarm);

	private:
		CString m_strPMCode;
		CString m_strPauseCode;
		short m_nByWho;
		int m_nMasterAlarm[13];
	};
}
