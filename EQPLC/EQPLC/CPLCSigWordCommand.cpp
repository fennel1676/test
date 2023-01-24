#include "StdAfx.h"
#include "CPLCSigWordCommand.h"


using namespace PLC;

CPLCSigWordCommand::CPLCSigWordCommand(void)
{
	memset(&m_stDateTime, 0x00, sizeof(DATETIME));
	memset(&m_stEQCmd, 0x00, sizeof(EQ_CMD));
	memset(&m_stProcessCmd, 0x00, sizeof(ProcessCommand));
	memset(&m_stPanelIDInfo, 0x00, sizeof(PanelIDInfo));
	memset(&m_stLimitWIPQTY, 0x00, sizeof(m_stLimitWIPQTY));
	memset(&m_szData, 0x00, sizeof(m_szData));
}

CPLCSigWordCommand::~CPLCSigWordCommand(void)
{
}

void CPLCSigWordCommand::GetData(char * szOutData)
{
	int nIndex = 0;

	MakeEQCmd(nIndex);
	MakeLimitWIPQTY(nIndex);
	MakeDateTime(nIndex);
	MakeProcessCmd(nIndex);
	//MakePanelIDInfo(nIndex);
	//MakeFlowCmd(nIndex);

	memcpy(szOutData, m_szData, sizeof(m_szData));
}

void CPLCSigWordCommand::MakeEQCmd(int &nIndex)
{
	char szBuf[80];

	//	CommandID
	memcpy(&m_szData[nIndex], &m_stEQCmd.nCommandID, 2);
	nIndex += 2;

	//	ByWho
	memcpy(&m_szData[nIndex], &m_stEQCmd.nByWho, 2);
	nIndex += 2;

	//	Code
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stEQCmd.szCode, strlen(m_stEQCmd.szCode));
	memcpy(&m_szData[nIndex], szBuf, 4);
	nIndex += 4;

	//	TerminalID
	memcpy(&m_szData[nIndex], &m_stEQCmd.nIDnNo, 2);
	nIndex += 2;

	//	Reserved
	nIndex += 2;

	//	TerminalText
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stEQCmd.szTerminalText, strlen(m_stEQCmd.szTerminalText));
	memcpy(&m_szData[nIndex], szBuf, 80);
	nIndex += 80;

	//	OpCallText
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stEQCmd.szOPCallText, strlen(m_stEQCmd.szOPCallText));
	memcpy(&m_szData[nIndex], szBuf, 80);
	nIndex += 80;

	/*memcpy(&m_szData[nIndex], &m_stEQCmd.nLimitWIPQTY1, 2);
	nIndex += 2;

	memcpy(&m_szData[nIndex], &m_stEQCmd.nLimitWIPQTY2, 2);
	nIndex += 2;*/

	////	Reserved
	//nIndex += 4;
}
void CPLCSigWordCommand::MakeLimitWIPQTY(int &nIndex)
{
	char szBuf[80];

	memcpy(&m_szData[nIndex], &m_stLimitWIPQTY.nLimitWIPQTY1, 2);
	nIndex += 2;

	memcpy(&m_szData[nIndex], &m_stLimitWIPQTY.nLimitWIPQTY2, 2);
	nIndex += 2;

	//	Reserved
	nIndex += 4;
}

void CPLCSigWordCommand::MakeDateTime(int &nIndex)
{
	//	Year
	memcpy(&m_szData[nIndex], &m_stDateTime.nYear, 2);
	nIndex += 2;

	//	Month
	memcpy(&m_szData[nIndex], &m_stDateTime.nMonth, 2);
	nIndex += 2;

	//	Day
	memcpy(&m_szData[nIndex], &m_stDateTime.nDay, 2);
	nIndex += 2;

	//	Hour
	memcpy(&m_szData[nIndex], &m_stDateTime.nHour, 2);
	nIndex += 2;

	//	Minute
	memcpy(&m_szData[nIndex], &m_stDateTime.nMinute, 2);
	nIndex += 2;

	//	Second
	memcpy(&m_szData[nIndex], &m_stDateTime.nSecond, 2);
	nIndex += 2;
}

void CPLCSigWordCommand::MakeProcessCmd(int &nIndex)
{
	char szBuf[16];
	char szTemp[4] = {0};
	
	nIndex = 192;
	switch(m_stProcessCmd.nPortNo)
	{
	case 1:  // Port1
		//	CommandID
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nCommandID, 2);
		nIndex += 2;

		//	ByWho
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nByWho, 2);
		nIndex += 2;

		//	CassetteID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stProcessCmd.szCassetteID, strlen(m_stProcessCmd.szCassetteID));
		memcpy(&m_szData[nIndex], &szBuf, 16);
		nIndex += 16;

		//	MapStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nMapStif, 4);
		nIndex += 4;

		//	StartStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nStartStif,4);
		nIndex += 4;

		
		nIndex += 84;
		break;
	case 2:  // Port2
		nIndex += 28;
		//	CommandID
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nCommandID, 2);
		nIndex += 2;

		//	ByWho
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nByWho, 2);
		nIndex += 2;

		//	CassetteID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stProcessCmd.szCassetteID, strlen(m_stProcessCmd.szCassetteID));
		memcpy(&m_szData[nIndex], &szBuf, 16);
		nIndex += 16;

		//	MapStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nMapStif, 4);
		nIndex += 4;

		//	StartStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nStartStif,4);
		nIndex += 4;

		nIndex +=56;
		break;
	case 3:  // Port3
		nIndex += 56;
		//	CommandID
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nCommandID, 2);
		nIndex += 2;

		//	ByWho
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nByWho, 2);
		nIndex += 2;

		//	CassetteID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stProcessCmd.szCassetteID, strlen(m_stProcessCmd.szCassetteID));
		memcpy(&m_szData[nIndex], &szBuf, 16);
		nIndex += 16;

		//	MapStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nMapStif, 4);
		nIndex += 4;

		//	StartStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nStartStif,4);
		nIndex += 4;

		nIndex += 28; 
		break;
	case 4:  // Port4
		nIndex += 84;
		//	CommandID
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nCommandID, 2);
		nIndex += 2;

		//	ByWho
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nByWho, 2);
		nIndex += 2;

		//	CassetteID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stProcessCmd.szCassetteID, strlen(m_stProcessCmd.szCassetteID));
		memcpy(&m_szData[nIndex], &szBuf, 16);
		nIndex += 16;

		//	MapStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nMapStif, 4);
		nIndex += 4;

		//	StartStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nStartStif,4);
		nIndex += 4;

		break;
	case 12:  // Port1
		//	CommandID
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nCommandID, 2);
		nIndex += 2;

		//	ByWho
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nByWho, 2);
		nIndex += 2;

		//	CassetteID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stProcessCmd.szCassetteID, strlen(m_stProcessCmd.szCassetteID));
		memcpy(&m_szData[nIndex], &szBuf, 16);
		nIndex += 16;

		//	MapStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nMapStif, 4);
		nIndex += 4;

		//	StartStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nStartStif,4);
		nIndex += 4;

		//	CommandID
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nCommandID, 2);
		nIndex += 2;

		//	ByWho
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nByWho, 2);
		nIndex += 2;

		//	CassetteID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stProcessCmd.szCassetteID, strlen(m_stProcessCmd.szCassetteID));
		memcpy(&m_szData[nIndex], &szBuf, 16);
		nIndex += 16;

		//	MapStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nMapStif, 4);
		nIndex += 4;

		//	StartStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nStartStif,4);
		nIndex += 4;

		nIndex +=56;
		break;
	case 34:  // Port34
		nIndex += 56;
		//	CommandID
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nCommandID, 2);
		nIndex += 2;

		//	ByWho
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nByWho, 2);
		nIndex += 2;

		//	CassetteID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stProcessCmd.szCassetteID, strlen(m_stProcessCmd.szCassetteID));
		memcpy(&m_szData[nIndex], &szBuf, 16);
		nIndex += 16;

		//	MapStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nMapStif, 4);
		nIndex += 4;

		//	StartStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nStartStif,4);
		nIndex += 4;

		//	CommandID
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nCommandID, 2);
		nIndex += 2;

		//	ByWho
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nByWho, 2);
		nIndex += 2;

		//	CassetteID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stProcessCmd.szCassetteID, strlen(m_stProcessCmd.szCassetteID));
		memcpy(&m_szData[nIndex], &szBuf, 16);
		nIndex += 16;

		//	MapStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nMapStif, 4);
		nIndex += 4;

		//	StartStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nStartStif,4);
		nIndex += 4;

		break;
	case 1234:  // Port1234
		//	CommandID
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nCommandID, 2);
		nIndex += 2;

		//	ByWho
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nByWho, 2);
		nIndex += 2;

		//	CassetteID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stProcessCmd.szCassetteID, strlen(m_stProcessCmd.szCassetteID));
		memcpy(&m_szData[nIndex], &szBuf, 16);
		nIndex += 16;

		//	MapStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nMapStif, 4);
		nIndex += 4;

		//	StartStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nStartStif,4);
		nIndex += 4;

		//	CommandID
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nCommandID, 2);
		nIndex += 2;

		//	ByWho
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nByWho, 2);
		nIndex += 2;

		//	CassetteID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stProcessCmd.szCassetteID, strlen(m_stProcessCmd.szCassetteID));
		memcpy(&m_szData[nIndex], &szBuf, 16);
		nIndex += 16;

		//	MapStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nMapStif, 4);
		nIndex += 4;

		//	StartStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nStartStif,4);
		nIndex += 4;

		//	CommandID
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nCommandID, 2);
		nIndex += 2;

		//	ByWho
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nByWho, 2);
		nIndex += 2;

		//	CassetteID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stProcessCmd.szCassetteID, strlen(m_stProcessCmd.szCassetteID));
		memcpy(&m_szData[nIndex], &szBuf, 16);
		nIndex += 16;

		//	MapStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nMapStif, 4);
		nIndex += 4;

		//	StartStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nStartStif,4);
		nIndex += 4;

		//	CommandID
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nCommandID, 2);
		nIndex += 2;

		//	ByWho
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nByWho, 2);
		nIndex += 2;

		//	CassetteID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stProcessCmd.szCassetteID, strlen(m_stProcessCmd.szCassetteID));
		memcpy(&m_szData[nIndex], &szBuf, 16);
		nIndex += 16;

		//	MapStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nMapStif, 4);
		nIndex += 4;

		//	StartStif
		memcpy(&m_szData[nIndex], &m_stProcessCmd.nStartStif,4);
		nIndex += 4;

		break;
	default:
		for(int i=0; i<4; i++)
		{
			//	CommandID
			memcpy(&m_szData[nIndex], &m_stProcessCmd.nCommandID, 2);
			nIndex += 2;

			//	ByWho
			memcpy(&m_szData[nIndex], &m_stProcessCmd.nByWho, 2);
			nIndex += 2;

			//	CassetteID
			memset(szBuf, ' ', sizeof(szBuf));
			memcpy(szBuf, m_stProcessCmd.szCassetteID, strlen(m_stProcessCmd.szCassetteID));
			memcpy(&m_szData[nIndex], &szBuf, 16);
			nIndex += 16;

			//	MapStif
			memcpy(&m_szData[nIndex], &m_stProcessCmd.nMapStif, 4);
			nIndex += 4;

			//	StartStif
			memcpy(&m_szData[nIndex], &m_stProcessCmd.nStartStif,4);
			nIndex += 4;

		}
		break;
	}
}

void CPLCSigWordCommand::MakePanelIDInfo(int &nIndex)
{
	nIndex = 304;
	char szBuf[20]={0};
	char szTemp[4] = {0};
	for(int i=0; i<4; i++)
	{
		//	HPanelID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(&m_szData[nIndex], &szBuf, 12);
		nIndex += 12;

		//	UniqueID
		memcpy(&m_szData[nIndex], &szTemp, 4);
		nIndex += 4;
		// Reserve_2
		nIndex +=4;
	}
	nIndex =304;
	switch(m_stPanelIDInfo.nPort)
	{
	case 1:
	//	HPanelID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stPanelIDInfo.szHPanelID, strlen(m_stPanelIDInfo.szHPanelID));
		memcpy(&m_szData[nIndex], &szBuf, 12);
		nIndex += 12;

		//	UniqueID
		for(int i=0; i<4; i++)
		{
			memcpy(&m_szData[nIndex], &m_stPanelIDInfo.nUniqueID[i], 1);
			nIndex += 1;
		}

		// Reserved
		nIndex +=4;
		break;
	case 2:
		nIndex +=20;
		//	HPanelID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stPanelIDInfo.szHPanelID, strlen(m_stPanelIDInfo.szHPanelID));
		memcpy(&m_szData[nIndex], &szBuf, 12);
		nIndex += 12;

		//	UniqueID
		for(int i=0; i<4; i++)
		{
			memcpy(&m_szData[nIndex], &m_stPanelIDInfo.nUniqueID[i], 1);
			nIndex += 1;
		}

		// Reserved
		nIndex +=4;
		break;
	case 3:
		nIndex +=40;
		//	HPanelID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stPanelIDInfo.szHPanelID, strlen(m_stPanelIDInfo.szHPanelID));
		memcpy(&m_szData[nIndex], &szBuf, 12);
		nIndex += 12;

		//	UniqueID
		for(int i=0; i<4; i++)
		{
			memcpy(&m_szData[nIndex], &m_stPanelIDInfo.nUniqueID[i], 1);
			nIndex += 1;
		}
		// Reserved
		nIndex +=4;
		break;
	case 4:
		nIndex +=60;
		//	HPanelID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stPanelIDInfo.szHPanelID, strlen(m_stPanelIDInfo.szHPanelID));
		memcpy(&m_szData[nIndex], &szBuf, 12);
		nIndex += 12;

		//	UniqueID
		for(int i=0; i<4; i++)
		{
			memcpy(&m_szData[nIndex], &m_stPanelIDInfo.nUniqueID[i], 1);
			nIndex += 1;
		}

		// Reserved
		nIndex +=4;
		break;
	default:
		for(int i=0; i<4; i++)
		{
			//	HPanelID
			memset(szBuf, ' ', sizeof(szBuf));
			memcpy(szBuf, m_stPanelIDInfo.szHPanelID, strlen(m_stPanelIDInfo.szHPanelID));
			memcpy(&m_szData[nIndex], &szBuf, 12);
			nIndex += 12;

			//	UniqueID
			for(int i=0; i<4; i++)
			{
				memcpy(&m_szData[nIndex], &m_stPanelIDInfo.nUniqueID[i], 1);
				nIndex += 1;
			}
			// Reserved
			nIndex +=4;
		}
		break;
	}
}

void CPLCSigWordCommand::MakeFlowCmd(int &nIndex)
{
	char szBuf[8];

	//	CommandID
	memcpy(&m_szData[nIndex], &m_stFlowCmd.nCommandID, 2);
	nIndex += 2;

	//	FlowNo
	memcpy(&m_szData[nIndex], &m_stFlowCmd.nFlowNo, 2);
	nIndex += 2;

	//	FlowID
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stFlowCmd.stFlowBody.szFlowID, strlen(m_stFlowCmd.stFlowBody.szFlowID));
	memcpy(&m_szData[nIndex], &szBuf, 4);
	nIndex += 4;

	//	Revision
	memcpy(&m_szData[nIndex], &m_stFlowCmd.stFlowBody.nRevision, 2);
	nIndex += 2;

	//	Year
	memcpy(&m_szData[nIndex], &m_stFlowCmd.stFlowBody.nYear, 2);
	nIndex += 2;

	//	Month
	memcpy(&m_szData[nIndex], &m_stFlowCmd.stFlowBody.nMonth, 2);
	nIndex += 2;

	//	Day
	memcpy(&m_szData[nIndex], &m_stFlowCmd.stFlowBody.nDay, 2);
	nIndex += 2;

	//	Hour
	memcpy(&m_szData[nIndex], &m_stFlowCmd.stFlowBody.nHour, 2);
	nIndex += 2;

	//	Minute
	memcpy(&m_szData[nIndex], &m_stFlowCmd.stFlowBody.nMinute, 2);
	nIndex += 2;

	//	Second
	memcpy(&m_szData[nIndex], &m_stFlowCmd.stFlowBody.nSecond, 2);
	nIndex += 2;

	//	FlowBody
	for(int i = 0; i < 10; i++)
	{
		memcpy(&m_szData[nIndex], &m_stFlowCmd.stFlowBody.nFlowBody[i], 2);
		nIndex += 2;
	}

	//	reserved
	nIndex += 2;

	short nFlowGroup = 0;
	short nBuf = 0;

	//	Flow Group
	memcpy(&m_szData[nIndex], &m_stFlowCmd.nFlowGroup, sizeof(short) * 10);
	nIndex += 20;
}


void CPLCSigWordCommand::SetDateTime1(DATETIME &stDateTime)
{
	memcpy(&m_stDateTime, &stDateTime, sizeof(DATETIME));
}

void CPLCSigWordCommand::SetEQCmd(EQ_CMD &stEQCmd)
{
	memcpy(&m_stEQCmd, &stEQCmd, sizeof(EQ_CMD));
}
void CPLCSigWordCommand::SetProcessCmd(ProcessCommand &stProcessCmd)
{
	memcpy(&m_stProcessCmd, &stProcessCmd, sizeof(ProcessCommand));
}
void CPLCSigWordCommand::SetPanelIDInfo(PanelIDInfo &stPanelIDInfo)
{
	memcpy(&m_stPanelIDInfo, &stPanelIDInfo, sizeof(PanelIDInfo));
}

void CPLCSigWordCommand::SetFlowCmd(FLOW_CMD &stFlowCmd)
{
	memcpy(&m_stFlowCmd, &stFlowCmd, sizeof(FLOW_CMD));
}

void CPLCSigWordCommand::SetLimitWIPQTY(LimitWIPQTY &stLimitWIPQTY)
{
	memcpy(&m_stLimitWIPQTY, &stLimitWIPQTY, sizeof(LimitWIPQTY));
}

