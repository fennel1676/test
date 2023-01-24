#include "StdAfx.h"
#include "MsgTransferGlassDataReport.h"

using namespace Message;

CMsgTransferGlassDataReport::CMsgTransferGlassDataReport(void)
{
	m_nMessageType = 3;
	m_nMessageCommand = 1;
}

CMsgTransferGlassDataReport::~CMsgTransferGlassDataReport(void)
{
}


const CString CMsgTransferGlassDataReport::GetMsg()
{
	CString msg;
	msg.Format(
		_T("<INFO>")_T("\n")
			_T("<EXIST>%s</EXIST>")_T("\n")
			_T("<EVENTID>%s</EVENTID>")_T("\n")
			_T("<H_PANELID>%s</H_PANELID>")_T("\n")
			_T("<E_PANELID>%s</E_PANELID>")_T("\n")
			_T("<PROCESSID>%s</PROCESSID>")_T("\n")
			_T("<PRODUCTID>%s</PRODUCTID>")_T("\n")
			_T("<STEPID>%s</STEPID>")_T("\n")
			_T("<BATCHID>%s</BATCHID>")_T("\n")
			_T("<PROD_TYPE>%s</PROD_TYPE>")_T("\n")
			_T("<PROD_KIND>%s</PROD_KIND>")_T("\n")
			_T("<PPID>%s</PPID>")_T("\n")
			_T("<FLOWID>%s</FLOWID>")_T("\n")
			_T("<PANEL_SIZE>%s</PANEL_SIZE>")_T("\n")
			_T("<THICKNESS>%s</THICKNESS>")_T("\n")
			_T("<COMP_COUNT>%s</COMP_COUNT>")_T("\n")
			_T("<PANEL_STATE>%s</PANEL_STATE>")_T("\n")
			_T("<READING_FLAG>%s</READING_FLAG>")_T("\n")
			_T("<INS_FLAG>%s</INS_FLAG>")_T("\n")
			_T("<PANEL_POSITION>%s</PANEL_POSITION>")_T("\n")
			_T("<JUDGEMENT>%s</JUDGEMENT>")_T("\n")
			_T("<CODE>%s</CODE>")_T("\n")
			_T("<FLOW_HISTORY>%s</FLOW_HISTORY>")_T("\n")
			_T("<UNIQUEID>%s</UNIQUEID>")_T("\n")
			_T("<COUNT1>%s</COUNT1>")_T("\n")
			_T("<COUNT2>%s</COUNT2>")_T("\n")
			_T("<GRADE>%s</GRADE>")_T("\n")
			_T("<MULTI_USE>%s</MULTI_USE>")_T("\n")
			_T("<GLASS_DATA>%s</GLASS_DATA>")_T("\n")
			_T("<PAIR_H_PANELID>%s</PAIR_H_PANELID>")_T("\n")
			_T("<PAIR_E_PANELID>%s</PAIR_E_PANELID>")_T("\n")
			_T("<PAIR_PRODUCTID>%s</PAIR_PRODUCTID>")_T("\n")
			_T("<PAIR_GRADE>%s</PAIR_GRADE>")_T("\n")
			_T("<FLOW_GROUP>%s</FLOW_GROUP>")_T("\n")
			_T("<DBR_RECIPE>%s</DBR_RECIPE>")_T("\n")
			_T("<REFER>%s</REFER>")_T("\n")
			_T("<CONTACT_POINT1>%s</CONTACT_POINT1>")_T("\n")
			_T("<CONTACT_POINT2>%s</CONTACT_POINT2>")_T("\n")
			_T("<FROM_EQNO>%s</FROM_EQNO>")_T("\n")
			_T("<TO_EQNO>%s</TO_EQNO>")_T("\n")
			_T("<SLOTID>%s</SLOTID>")_T("\n")
			//_T("<REFUSE_CODE>%s</REFUSE_CODE>")
			//_T("<SIGNAL>%s</SIGNAL>")
		_T("</INFO>"), strExist, strEventID, strHPanelID, strEPanelID, strProcessID, strProductID, strStepID,
				strBatchID, strProdType, strProdKind, strPPID, strFlowID, strPanelSize, strThickness, strCompCount,
				strPanelState, strReadingFlag, strInsFlag, strPanelPosition, strJudgement, strCode, strFlowHistory,
				strUniqueID, strCount1, strCount2, strGrade, strMutiUse, strGlassDataBitSignal, strPairHPanelID,
				strPairEPanelID, strPairProductID, strPairGrade, strFlowGroup, strDBRRecipe, strReferData,
				strContactPointState1, strContactPointState2, strFromEQNo, strToEQNo, strSlotID);//, strRefuseCode, strHSSignalBit);

	return msg;
}

