#pragma once

namespace PLC
{
	struct GLASS_DATA
	{
		BOOL m_bInOut;
		short m_nGlassExistFlag;
		short m_nEventID;
		CString m_strHPanelID;
		CString m_strEPanelID;
		CString m_strProcessID;
		CString m_strProductID;
		CString m_strStepID;
		CString m_strBatchID;
		CString m_strProdType;
		CString m_strProdKind;
		CString m_strPPID;
		CString m_strFlowID;
		char m_szPanelSize[32];
		short m_nThickness;
		short m_nCompCount;
		short m_nPanelState;
		CString m_strReadingFlag;
		CString m_strInsFlag;
		CString m_strPanelPosition;
		CString m_strJudgement;
		CString m_strJudgementCode;
		char m_szFlowHistory[128];
		char m_szUniqueID[32];
		CString m_strCount1;
		CString m_strCount2;
		char m_szGrade[128];
		CString m_strMultiUse;
		char m_szGlassDataSignal[64];
		CString m_strPairHPanel;
		CString m_strPairEPanel;
		CString m_strPairProductID;
		char m_szPairGrade[128];
		char m_szFlowGroup[128];
		CString m_strDBRRecipe;
		CString m_strRefer;
		CString m_strContactPointState1;
		CString m_strContactPointState2;
		short m_nFromEQNo;
		short m_nToEQNo;
		CString m_strSlotID;
		CString m_strRefuseCode;
		short m_nHSSignalBits;
	};

	struct FLOW_RECIPE_BODY
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

	struct MANUAL_DISPATCH_RULE
	{
		short nUnitNo;
		short nDispatchOption;
		char szDeviceID[24];
		short nRunLine;
		int nTarget;
	};

	struct JUDGEMENT_FLOW
	{
		short nUnitNo;
		char szJudgement[44];
		long nTarget;
	};

	struct SUB_EQ_STATE
	{
		char szPPID[12];
		short nTactSet;
		short nTactCurrent;
		short nEQState;
		short nProcessState;
	};

	struct PortInfoItem
	{
		int m_nEventID;
		CString m_strPortID;
		int m_nPortState;
		int m_nPortType;
		CString m_strPortMode;
		int m_nSortType;
		int m_nCSTDemand;
		CString m_strCSTID;
		CString m_strCSTType;
		CString m_strMat_Stif;
		CString m_strCur_Stif;
		int m_nBatch_Order;
		short m_nByWho;
		short m_nReply;
	};

	struct OldPortInfoItem
	{
		int m_nOldEentID;
		int m_nOldPortState;
		char m_strOldMat_Stif[4];
		char m_strOldCur_Stif[4];
	};

	struct WIPQTY
	{
		int nWIPQTY1PLC1;
		int nWIPQTY1PLC2;
		int nWIPQTY2PLC1;
		int nWIPQTY2PLC2;
	};

	struct ProcessItem
	{
		short nCommandID;
		short nByWho;
		CString CSTID;
		int nMap_Stif;
		int nStart_Stif;
	};

	interface IPLCEvent
	{
		virtual void EventSignalBitDataSend(int nPLCNo) = 0;
		virtual void EventSignalPLCAlive(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalDatetimeSet(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalEquipmentCmd(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalFlowCtrlCmd(int nPLCNo) = 0;

		virtual void EventSignalProcessPort1Cmd(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalProcessPort2Cmd(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalProcessPort3Cmd(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalProcessPort4Cmd(int nPLCNo, BOOL bSet) = 0;

		virtual void EventSignalPCData1Cmd(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPCData2Cmd(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPCData3Cmd(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPCData4Cmd(int nPLCNo, BOOL bSet) = 0;

		virtual void EventCassetteInfoSend1(int nPLCNo) = 0;
		virtual void EventCassetteInfoSend2(int nPLCNo) = 0;
		virtual void EventCassetteInfoSend3(int nPLCNo) = 0;
		virtual void EventCassetteInfoSend4(int nPLCNo) = 0;
		virtual void EventSignalTerminalMsgCmd(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalOPCallCmd(int nPLCNo, BOOL bSet) = 0;

		virtual void EventSignalPort1State(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPort2State(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPort3State(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPort4State(int nPLCNo, BOOL bSet) = 0;

		virtual void EventSignalPort1InitReq(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPort2InitReq(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPort3InitReq(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPort4InitReq(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPanelID1ReqEvt(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPanelID2ReqEvt(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPanelID3ReqEvt(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPanelID4ReqEvt(int nPLCNo, BOOL bSet) = 0;

		virtual void ECInfoCmdReply(int nPLCNo) = 0;

		virtual void EventSignalPort1(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPort2(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPort3(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPort4(int nPLCNo, BOOL bSet) = 0;
		
		virtual void EventSignalFlowRecipe(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalUnitReport(int nPLCNo, int nUnitNo, BOOL bSet) = 0;
		virtual void EventSignalUnitCtrlCmd(int nPLCNo, int nUnitNo) = 0;
		virtual void EventCommonState(int nPLCNo, CString &strPMCode, CString &strPauseCode, short nByWho) = 0;
		virtual void EventState(int nPLCNo, int nUnitNo, int nEQnProcessStatus, short nByWhoEQ, short nByWhoProcess) = 0;
		virtual void EventMasterAlarm(int nPLCNo, int nMasterAlarmNo, int nMasterAlarm, BOOL bAlarm) = 0;
		virtual void EventUnitAlarm(int nPLCNo, int nUnitNo, int nUnitAlarm, BOOL bAlarm) = 0;
		virtual void EventPanel(int nPLCNo, int nUnitNo, int nEventID, CString &strHPanelID, CString strBrokenCode) = 0;
		virtual void EventHSSignal(int nPLCNo, int nUnitNo, int nHSSignalBits, CString &strRefuseCode, short nRefuseBit, BOOL bFlag) = 0;
		virtual void EventGlassDataReq(int nPLCNo, int nUnitNo) = 0;
		virtual void EventGlassData(int nPLCNo, int nUnitNo, GLASS_DATA &stGlassData) = 0;
		virtual void EventWIPQTY(int nPLCNo, PLC::WIPQTY &stWIPQTY) = 0;
		virtual void EventEQRecipeTable(int nPLCNo, short nEventID, short nFlowRecipeNo, short* pFlowGroup) = 0;

		virtual void EventPort(int nPLCNo, PortInfoItem strPortInfoItem, int nPortNum) = 0;
		virtual void EventEQRecipeBody(int nPLCNo, int nStartIndex, FLOW_RECIPE_BODY* pstFlowRecipeBody) = 0;

		virtual void EventSignalPLCData1(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPLCData2(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPLCData3(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPLCData4(int nPLCNo, BOOL bSet) = 0;

		virtual void EventSignalPort1Duplication(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPort2Duplication(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPort3Duplication(int nPLCNo, BOOL bSet) = 0;
		virtual void EventSignalPort4Duplication(int nPLCNo, BOOL bSet) = 0;

	};

	interface IPLC
	{
		IPLC()										
		{m_nVarID = nRefCnt; nRefCnt++; m_bOnline = FALSE;}

		static int nRefCnt;
		static IPLCEvent *pPLCEvent;
		virtual void SetData(const char *szTagName, char *pData){}
		virtual void GetData(char *pData)			{pData = NULL;}
		int GetPLCNo()								{return m_nPLCNo;}
		virtual void SetTagName(CString strTagName)
		{
			m_strTagName = strTagName;

			CString strPLCNo;
			AfxExtractSubString(strPLCNo, strTagName, 1, '_');
			m_nPLCNo = atoi(strPLCNo.operator LPCTSTR()) - 1;
		}
		CString &GetTagName()						{return m_strTagName;}
		int GetVarID()								{return m_nVarID;}
		void SetOnline(BOOL bOnline)				{m_bOnline = bOnline;}
		BOOL IsOnline()								{return m_bOnline;}

	private:
		CString m_strTagName;
		int m_nPLCNo;
		int m_nVarID;
		BOOL m_bOnline;
	};
}
