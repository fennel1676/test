#include "StdAfx.h"
#include "MsgInitializeUnitStateReport.h"

using namespace Message;

CMsgInitializeUnitStateReport::CMsgInitializeUnitStateReport(void)
{
	m_nMessageType = 3;
	m_nMessageCommand = 5;
	m_nUnitCount = 0;

	memset(m_stUnitState, 0x00, sizeof(UNIT_STATE) * 81);

	for(int i = 0; i < 81; i++)
		m_stUnitState[i].nUnitID = i+1;
}

CMsgInitializeUnitStateReport::~CMsgInitializeUnitStateReport(void)
{
}

void CMsgInitializeUnitStateReport::Add(int nUnitID, int nEQState, int nProcessState)
{
	if(m_nUnitCount < nUnitID)	m_nUnitCount = nUnitID;
//	m_stUnitState[nUnitID - 1].nUnitID = nUnitID;
	m_stUnitState[nUnitID - 1].nEQState = nEQState;
	m_stUnitState[nUnitID - 1].nProcessState = nProcessState;
}

const CString CMsgInitializeUnitStateReport::GetMsg()
{
	CString msg;
	CString unitMsg;
	for(size_t i = 0; i < m_nUnitCount; i++)
	{
		unitMsg.Format(
			_T("<INFO>")_T("\n")
				_T("<ID>Unit#%02d</ID>")_T("\n")
				_T("<EQ_STATE>%d</EQ_STATE>")_T("\n")		
				_T("<PROCESS_STATE>%d</PROCESS_STATE>")_T("\n")		
			_T("</INFO>"),
			m_stUnitState[i].nUnitID, m_stUnitState[i].nEQState, m_stUnitState[i].nProcessState);

		msg += unitMsg;
	}

	return msg;
}
