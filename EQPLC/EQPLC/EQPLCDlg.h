// EQPLCDlg.h : 헤더 파일
//

#pragma once

//#include <..\inc\log4cxx\logger.h>
//#include <log4cxx/basicconfigurator.h>
//#include <log4cxx/propertyconfigurator.h>
//#include <log4cxx/helpers/exception.h>
//
//using namespace log4cxx;
//using namespace log4cxx::helpers;

#include "EIP.h"
#include "IPLC.h"
#include "IEIPEvent.h"

#include "LCIFDlg.h"

#include "PLCState.h"
#include "PLCGlassData.h"
#include "PLCStateUnitGroup.h"
#include "PLCSignalCommand.h"
#include "PLCSigWordCommand3.h"
#include "PLCSignalEvent.h"
#include "CPLCSigWordCommand.h"
#include "PLCEQRecipeTable.h"
#include "PLCEQRecipeBody.h"
#include "CPLCSigEventObject.h" //새로추가
#include "CPLCEventObjectUnit.h" //새로추가
#include "PLCCassetteInfoCommand.h" //새로 추가
#include "CPLCPanelIDInfo.h"
#include "PLCWIPQTYEvent.h"
#include ".\MessageInfo\MsgInitializeUnitStateReport.h"
#include ".\MessageInfo\MsgInitializeAlarmReport.h"
#include ".\MessageInfo\MsgInitalizeWIPQTYReport.h"
//#include ".\MessageInfo\MsgMessageCommand.h"

#include "SingleThread.h"
#include "ABConfig.h"

#pragma warning(push)
#pragma warning(disable : 4786)
#include <vector>
#include <deque>
#include <algorithm>
#include "afxwin.h"
#include "afxcmn.h"
#pragma warning(pop) 
using namespace std;
using namespace Message;

class CXMLMsg;

#define WM_EVENT_GLASS_REQ		WM_USER+1
#define WM_EVENT_SIGNAL_BIT		WM_USER+2
#define WM_EVENT_SIGNAL_WORD1	WM_USER+3
#define WM_EVENT_SIGNAL_WORD3	WM_USER+4
#define WM_EVENT_PANELIDL_INFO	WM_USER+5
#define WM_EVENT_CASSETTE_INFO1	WM_USER+6
#define WM_EVENT_CASSETTE_INFO2	WM_USER+7
#define WM_EVENT_CASSETTE_INFO3	WM_USER+8
#define WM_EVENT_CASSETTE_INFO4	WM_USER+9
#define WM_EVENT_DATA_CHANG		WM_USER+10
#define WM_EVENT_TRAY_ICON		WM_USER+11
#define WM_EVENT_PORT           WM_USER+12

//ProcessCommandTest
#define WM_EVENT_SIGNAL_WORD1_TEST	WM_USER+20

// CEQPLCDlg 대화 상자
class CEQPLCDlg : public CDialog, public IEIPEvent, public PLC::IPLCEvent, public CSingleThread
{
public:
	struct DATA_CHANGE
	{
		CString strTagName;
		int nVarID;
		char szData[500];
	};
	struct DATA_MESSAGE
	{
		int nPLCNo;
		int nNum;
		CString strTerminal;
		CString strOPCall;
	};

	struct COMMON_STATE
	{
		CString strPMCode;
		CString strPauseCode;
		short nByWho;
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
	};

	struct ProcessCommand
	{
		short m_nCommandID;
		short m_nByWho;
		CString m_strCSTID;
		int m_nMap_Stif;
		int m_nStart_Stif;
	};

	//struct DuplicatedItem
	//{
	//	int nPLCNo;
	//	int nPortNo;
	//	CString strH_PanelID;
	//	CString strUniqueID;
	//	CString strResult1;
	//	CString strResult2;
	//	CString strResult3;
	//}

	// 생성입니다.
public:
	CEQPLCDlg(CWnd* pParent = NULL);	// 표준 생성자입니다.
	virtual ~CEQPLCDlg();

// 대화 상자 데이터입니다.
	enum { IDD = IDD_EQPLC_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV 지원입니다.


// 구현입니다.
protected:
	HICON m_hIcon;

	// 생성된 메시지 맵 함수
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()

public:
	LRESULT OnLCConnect(WPARAM wParam, LPARAM lParam);
	LRESULT OnGlassInfoReq(WPARAM wParam, LPARAM lParam);
	LRESULT OnSignalBit(WPARAM wParam, LPARAM lParam);
	LRESULT OnSignalWord1(WPARAM wParam, LPARAM lParam);
	// ProcessCommandTest
	LRESULT OnSignalWord1Test(WPARAM wParam, LPARAM lParam);

	LRESULT OnCassetteInfo1(WPARAM wParam, LPARAM lParam);
	LRESULT OnCassetteInfo2(WPARAM wParam, LPARAM lParam);
	LRESULT OnCassetteInfo3(WPARAM wParam, LPARAM lParam);
	LRESULT OnCassetteInfo4(WPARAM wParam, LPARAM lParam);


	LRESULT OnSignalWord2(WPARAM wParam, LPARAM lParam);
	LRESULT OnSignalWord3(WPARAM wParam, LPARAM lParam);
	LRESULT OnPanelIDInfo(WPARAM wParam, LPARAM lParam);
	LRESULT OnTrayIcon(WPARAM wParam, LPARAM lParam);
	LRESULT OnLC(WPARAM wParam, LPARAM lParam);
	LRESULT OnPortEvent(WPARAM wParam,LPARAM lParam);
	virtual void ThreadFunc();
public:

private:
	CRITICAL_SECTION m_stCriticalSection;
	BOOL m_bSection;

	CEIP m_objEIP;
	CLCIFDlg m_LCIFDlg;
	BOOL m_bEQOnline;
	char m_szUnitName[100][32];
	char m_szMasterAlarmName[32];
	CString m_strEQName;
	CString m_strEQIP;
	int m_nKeepAlive;
	COMMON_STATE m_stCommonState;

	BOOL m_bInit;
	//Message::CMsgInitalizeWIPQTYReport m_objInitWIPQTYEvent;
	Message::CMsgInitializeUnitStateReport m_objInitStateReport;
	Message::CMsgInitializeAlarmReport m_objInitAlarmReport;

	//	Command Bit & Word
	PLC::CPLCSignalCommand *m_pPLCSignalCommand;
	PLC::CPLCSigWordCommand* m_pPLCSigWordCommand;
	PLC::CPLCSigWordCommand3* m_pPLCSigWordCommand3;
	PLC::CPLCPanelIDInfo* m_pPLCPanelIDInfo;

	// CassetteInfo Command
	PLC::CPLCCassetteInfoCommand *m_pCassetteInfoCommand1;
	PLC::CPLCCassetteInfoCommand *m_pCassetteInfoCommand2;
	PLC::CPLCCassetteInfoCommand *m_pCassetteInfoCommand3;
	PLC::CPLCCassetteInfoCommand *m_pCassetteInfoCommand4;

	// ProcessCommand Test
	PLC::CPLCSigWordCommand* m_pPLCSigWordCommandTest;

	//	Flow Recipe Event
	short m_nEventID;
	short m_nFlowRecipeNo;
	PLC::FLOW_RECIPE_BODY m_nEQFlowRecipeBody[50];
	short m_nEQFlowGroup[10];

	// Port Event
	PortInfoItem m_strPortInfoItem[4];

	vector<PLC::IPLC *> m_vtEQPLC;
	deque<DATA_CHANGE *> m_dqDataChange;
	deque<DATA_MESSAGE *> m_dqEQCommand;

public:
	void LoadPLCInfo();
	void LoadInfo();
	bool OnLCEvent(CXMLMsg &xmlMsg);
	virtual void StatusEventProduced(int nVarId, BOOL bOnline);
	virtual void StatusEventConsumed(int nVarId, BOOL bOnline);
	virtual void DataChangeEvent(const char *szTagName, int nVarID, char *pData);
	virtual void DataMessageChangeEvent(int nPLCNo, int nNum, CString strTerminal, CString strOPCall);
	void DataMessageChange(int nPLCNo, int nNum, CString strTerminal, CString strOPCall);

	virtual void EventSignalBitDataSend(int nPLCNo);
	virtual void EventCassetteInfoSend1(int nPLCNo);
	virtual void EventCassetteInfoSend2(int nPLCNo);
	virtual void EventCassetteInfoSend3(int nPLCNo);
	virtual void EventCassetteInfoSend4(int nPLCNo);

	void EventSigWordData1Send(int nPLCNo);
	void EventSigWordData3Send(int nPLCNo);
	void EventSigPanelIDInfo(int nPLCNo);

	// ProcessCommand Test
	void EventSigWordData1SendTest(int nPLCNo);

	virtual void EventSignalPLCAlive(int nPLCNo, BOOL bSet);
	virtual void EventSignalDatetimeSet(int nPLCNo, BOOL bSet);
	virtual void EventSignalEquipmentCmd(int nPLCNo, BOOL bSet);
	virtual void EventSignalFlowCtrlCmd(int nPLCNo);

	virtual void EventSignalProcessPort1Cmd(int nPLCNo, BOOL bSet);
	virtual void EventSignalProcessPort2Cmd(int nPLCNo, BOOL bSet);
	virtual void EventSignalProcessPort3Cmd(int nPLCNo, BOOL bSet);
	virtual void EventSignalProcessPort4Cmd(int nPLCNo, BOOL bSet);

	virtual void EventSignalPCData1Cmd(int nPLCNo, BOOL bSet);
	virtual void EventSignalPCData2Cmd(int nPLCNo, BOOL bSet);
	virtual void EventSignalPCData3Cmd(int nPLCNo, BOOL bSet);
	virtual void EventSignalPCData4Cmd(int nPLCNo, BOOL bSet);

	virtual void EventSignalTerminalMsgCmd(int nPLCNo, BOOL bSet);
	virtual void EventSignalOPCallCmd(int nPLCNo, BOOL bSet);

	virtual void EventSignalPort1State(int nPLCNo, BOOL bSet);
	virtual void EventSignalPort2State(int nPLCNo, BOOL bSet);
	virtual void EventSignalPort3State(int nPLCNo, BOOL bSet);
	virtual void EventSignalPort4State(int nPLCNo, BOOL bSet);

	virtual void EventSignalPort1InitReq(int nPLCNo, BOOL bSet);
	virtual void EventSignalPort2InitReq(int nPLCNo, BOOL bSet);
	virtual void EventSignalPort3InitReq(int nPLCNo, BOOL bSet);
	virtual void EventSignalPort4InitReq(int nPLCNo, BOOL bSet);

	virtual void EventSignalPanelID1ReqEvt(int nPLCNo, BOOL bSet);
	virtual void EventSignalPanelID2ReqEvt(int nPLCNo, BOOL bSet);
	virtual void EventSignalPanelID3ReqEvt(int nPLCNo, BOOL bSet);
	virtual void EventSignalPanelID4ReqEvt(int nPLCNo, BOOL bSet);

	virtual void ECInfoCmdReply(int nPLCNo);

	virtual void EventSignalFlowRecipe(int nPLCNo, BOOL bSet);

	virtual void EventSignalPort1(int nPLCNo, BOOL bSet);
	virtual void EventSignalPort2(int nPLCNo, BOOL bSet);
	virtual void EventSignalPort3(int nPLCNo, BOOL bSet);
	virtual void EventSignalPort4(int nPLCNo, BOOL bSet);

	virtual void EventSignalUnitReport(int nPLCNo, int nUnitNo, BOOL bSet);
	virtual void EventSignalUnitCtrlCmd(int nPLCNo, int nUnitNo);
	virtual void EventCommonState(int nPLCNo, CString &strPMCode, CString &strPauseCode, short nByWho);
	virtual void EventState(int nPLCNo, int nUnitNo, int nEQnProcessStatus, short nByWhoEQ, short nByWhoProcess);
	virtual void EventMasterAlarm(int nPLCNo, int nMasterAlarmNo, int nMasterAlarm, BOOL bAlarm);
	virtual void EventUnitAlarm(int nPLCNo, int nUnitNo, int nUnitAlarm, BOOL bAlarm);
	virtual void EventPanel(int nPLCNo, int nUnitNo, int nEventID, CString &strHPanelID, CString strBrokenCode);
	virtual void EventHSSignal(int nPLCNo, int nUnitNo, int nHSSignalBits, CString &strRefuseCode, short nRefuseBit, BOOL bFlag);
	virtual void EventGlassDataReq(int nPLCNo, int nUnitNo);
	virtual void EventGlassData(int nPLCNo, int nUnitNo, PLC::GLASS_DATA &stGlassData);
	virtual void EventWIPQTY(int nPLCNo, PLC::WIPQTY &stWIPQTY);

	virtual void EventPort(int nPLCNo, PLC::PortInfoItem strPortInfoItem, int nPortNum);
	virtual void EventEQRecipeTable(int nPLCNo, short nEventID, short nFlowRecipeNo, short* pFlowGroup);
	virtual void EventEQRecipeBody(int nPLCNo, int nStartIndex, PLC::FLOW_RECIPE_BODY* pstFlowRecipeBody);

	virtual void EventSignalPLCData1(int nPLCNo, BOOL bSet);
	virtual void EventSignalPLCData2(int nPLCNo, BOOL bSet);
	virtual void EventSignalPLCData3(int nPLCNo, BOOL bSet);
	virtual void EventSignalPLCData4(int nPLCNo, BOOL bSet);

	virtual void EventSignalPort1Duplication(int nPLCNo, BOOL bSet);
	virtual void EventSignalPort2Duplication(int nPLCNo, BOOL bSet);
	virtual void EventSignalPort3Duplication(int nPLCNo, BOOL bSet);
	virtual void EventSignalPort4Duplication(int nPLCNo, BOOL bSet);

	virtual void PCDataReply1(int nPLCNo, BOOL bSet);
	virtual void PCDataReply2(int nPLCNo, BOOL bSet);
	virtual void PCDataReply3(int nPLCNo, BOOL bSet);
	virtual void PCDataReply4(int nPLCNo, BOOL bSet);

	//CommonState Class1을 UCMM으로 가져오기
	void CommonStateReq(int nPLCNo, int nUnitNo);
	void DuplicatedDataReq(int nPLCNo,int nPortNo, CString &strH_PanelID, CString &strUniqueID, CString &strResult1, CString &strResult2, CString &strResult3);
	void PLCDataReq(int nPLCNo,int nPortNo, ProcessCommand &stProcessCommand);

	afx_msg void OnBnClickedCancel();
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	void CreateTrayIcon(const char* szToolTip);

	CListCtrl m_ctrlListPC;
	CString m_strPCTag[33]; // Signal Tag
	CString m_strPLCTag[33];
	CListCtrl m_ctrlListPLC;

	afx_msg void OnBnClickedRadioManual();
	afx_msg void OnBnClickedRadioAuto();
	afx_msg void OnBnClickedButtonPort1On();
	afx_msg void OnBnClickedButtonPort1Off();
	afx_msg void OnBnClickedButtonPort2On();
	afx_msg void OnBnClickedButtonport2Off();
	afx_msg void OnBnClickedButtonPort3On();
	afx_msg void OnBnClickedButtonPort3Off();
	afx_msg void OnBnClickedButtonPort4On();
	afx_msg void OnBnClickedButtonport4Off();
	afx_msg void OnTrayEnd();
	afx_msg void OnBinaryLogOn();
	afx_msg void OnXMLLogOn();
	afx_msg void OnCloseProgram();

	NOTIFYICONDATA m_Ndata; //Tray Icon
	int m_nIconNo;
	BOOL m_bPLCConnect;
	afx_msg void OnWindowPosChanging(WINDOWPOS* lpwndpos);
	BOOL m_bvisible;
	afx_msg void OnBnClickedButtonOnoff();
	int m_nCount;

	void ConnectionEvent(int nResult);
	int m_nResult;
};
