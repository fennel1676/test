#pragma once

#include "IPLC.h"

namespace PLC
{
	class CPLCSigWordCommand : public IPLC
	{
	public:
		struct EQ_CMD
		{
			short nCommandID;
			short nByWho;
			char szCode[8];
			short nIDnNo;
			char szTerminalText[84];
			char szOPCallText[84];
			//int nLimitWIPQTY1;
			//int nLimitWIPQTY2;
		};
		struct DATETIME
		{
			short nYear;
			short nMonth;
			short nDay;
			short nHour;
			short nMinute;
			short nSecond;
		};
		struct FLOW_BODY
		{
			char szFlowID[8];
			short nRevision;
			short nYear;
			short nMonth;
			short nDay;
			short nHour;
			short nMinute;
			short nSecond;
			short nFlowBody[10];
		};
		struct FLOW_CMD
		{
			short nCommandID;
			short nFlowNo;
			FLOW_BODY stFlowBody;
			short nFlowGroup[10];
		};

		struct ProcessCommand
		{
			int nPortNo;
			short nCommandID;
			char szCassetteID[112];
			int nMapStif;
			int nStartStif;
			short nByWho;
		};

		struct PanelIDInfo
		{
			int nPort;
			char szHPanelID[12];
			char szUniqueID[4];
			int nUniqueID[4];
		};

		struct LimitWIPQTY
		{
			int nLimitWIPQTY1;
			int nLimitWIPQTY2;
		};


	public:
		CPLCSigWordCommand(void);
		virtual ~CPLCSigWordCommand(void);

	public:
		virtual void GetData(char * szOutData);
		void SetDateTime1(DATETIME &stDateTime);
		void SetEQCmd(EQ_CMD &stEQCmd);
		void SetProcessCmd(ProcessCommand &stProcessCmd);
		void SetPanelIDInfo(PanelIDInfo &stPanelIDInfo);
		void SetFlowCmd(FLOW_CMD &stFlowCmd);
		void SetLimitWIPQTY(LimitWIPQTY &m_stLimitWIPQTY);

	private:
		void MakeEQCmd(int &nIndex);
		void MakeDateTime(int &nIndex);
		void MakeProcessCmd(int &nIndex);
		void MakePanelIDInfo(int &nIndex);
		void MakeFlowCmd(int &nIndex);
		void MakeLimitWIPQTY(int &nIndex);
	
	private:
		char m_szData[384];

		EQ_CMD m_stEQCmd;
		DATETIME m_stDateTime;
		ProcessCommand m_stProcessCmd;
		PanelIDInfo m_stPanelIDInfo;
		FLOW_CMD m_stFlowCmd;
		LimitWIPQTY m_stLimitWIPQTY;
	};
}