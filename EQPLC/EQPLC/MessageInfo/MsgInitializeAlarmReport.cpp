#include "StdAfx.h"
#include "MsgInitializeAlarmReport.h"

using namespace Message;

CMsgInitializeAlarmReport::CMsgInitializeAlarmReport(void)
{
	m_nMessageType = 3;
	m_nMessageCommand = 8;

	m_nUnitCount = 0;

	memset(&m_stMasterAlarm, 0x00, sizeof(INIT_ALARM) * 10);
	memset(&m_stUnitAlarm, 0x00, sizeof(INIT_ALARM) * 81);
}

CMsgInitializeAlarmReport::~CMsgInitializeAlarmReport(void)
{
}

void CMsgInitializeAlarmReport::AddMaster(int nAlarmMaster, int nAlarmValue, BOOL bSet)
{
	if(bSet)	m_stMasterAlarm[nAlarmMaster - 1].nAlarmValue[nAlarmValue - 1] = nAlarmValue + 32 * (nAlarmMaster - 1);
	else		m_stMasterAlarm[nAlarmMaster - 1].nAlarmValue[nAlarmValue - 1] = 0;
}

void CMsgInitializeAlarmReport::AddUnit(int nAlarmUnit, int nAlarmValue, BOOL bSet)
{
	if(m_nUnitCount < nAlarmUnit)	m_nUnitCount = nAlarmUnit;

	m_stUnitAlarm[nAlarmUnit - 1].nAlarmUnit = nAlarmUnit;
	if(bSet)	m_stUnitAlarm[nAlarmUnit - 1].nAlarmValue[nAlarmValue - 1] = nAlarmValue;
	else		m_stUnitAlarm[nAlarmUnit - 1].nAlarmValue[nAlarmValue - 1] = 0;
}

const CString CMsgInitializeAlarmReport::GetMsg()
{
	CString msg;
	CString unitMsg;
	size_t i, j;
	for(i = 0; i < 10; i++)
	{
		for(j = 0; j < 32; j++)
		{
			if(0 != m_stMasterAlarm[i].nAlarmValue[j])
			{
				unitMsg.Format(
					_T("<INFO>")_T("\n")
						_T("<UNIT>Master</UNIT>")_T("\n")
						_T("<VALUE>%d</VALUE>")_T("\n")
					_T("</INFO>"),
					m_stMasterAlarm[i].nAlarmValue[j]);
				msg += unitMsg;
			}
		}
	}

	for(i = 0; i < m_nUnitCount; i++)
	{
		for(j = 0; j < 32; j++)
		{
			if(0 != m_stUnitAlarm[i].nAlarmValue[j])
			{
				unitMsg.Format(
					_T("<INFO>")_T("\n")
						_T("<UNIT>Unit#%02d</UNIT>")_T("\n")
						_T("<VALUE>%d</VALUE>")_T("\n")
					_T("</INFO>"),
					m_stUnitAlarm[i].nAlarmUnit, m_stUnitAlarm[i].nAlarmValue[j]);
				msg += unitMsg;
			}
		}
	}

	return msg;
}

