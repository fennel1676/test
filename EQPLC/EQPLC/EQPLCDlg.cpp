// EQPLCDlg.cpp : 구현 파일
//

#include "stdafx.h"
#include "EQPLC.h"
#include "EQPLCDlg.h"
#include ".\MessageInfo\MsgDateTimeCommand.h"
#include ".\MessageInfo\MsgEquipmentCommand.h"
#include ".\MessageInfo\MsgFlowRecipeControlCommand.h"
#include ".\MessageInfo\MsgFlowGroupControlCommand.h"
#include ".\MessageInfo\MsgProcessCommand.h"
#include ".\MessageInfo\MsgPanelIDInfo.h"
#include ".\MessageInfo\MsgOnlineModeCommand.h"
#include ".\MessageInfo\MsgMessageCommand.h"
#include ".\MessageInfo\MsgEQConstantCommand.h"
#include ".\MessageInfo\MsgEQOnlineParameterCommand.h"
#include ".\MessageInfo\MsgAlarmResetCommand.h"
#include ".\MessageInfo\MsgTransferGlassDataReport.h"
#include ".\MessageInfo\MsgGlassControlReport.h"
#include ".\MessageInfo\MsgAlarmReport.h"
#include ".\MessageInfo\MsgUnitStateReport.h"
#include ".\MessageInfo\MsgSignalBitsReport.h"
#include ".\MessageInfo\MsgFlowGroupEvent.h"
#include ".\MessageInfo\MsgFlowRecipeEvent.h"
#include ".\MessageInfo\MsgManualDispatchEvent.h"
#include ".\MessageInfo\MsgEQConstantEvent.h"
#include ".\MessageInfo\MsgEQPMEvent.h"
#include ".\MessageInfo\MsgPanelIDEvent.h"
#include ".\MessageInfo\CMsgPortEvent.h"
#include ".\MessageInfo\MsgCassetteInfoCommand.h"
#include ".\MessageInfo\MsgPortStartCommand.h"
#include ".\MessageInfo\MsgLimitWIPQTYCommand.h"
#include "MessageInfo\MsgWIPQTYEvent.h"
#include "MessageInfo\MsgPortInitReqEvent.h"
#include "MessageInfo\MsgPortPauseEvent.h"
#include "MessageInfo\MsgPortResumeEvent.h"
#include "MessageInfo\MsgPortDuplicationEvent.h"
#include "MessageInfo\MsgConnectionEvent.h"
#include "MessageInfo\MsgPLCSignalEvent.h"
#include "MessageInfo\MsgPLCDataEvent.h"
#include "MessageInfo\MsgPCDataCommand.h"



#include "XMLMsg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CEqPLCDlg 대화 상자
using namespace Message;
using namespace PLC;

PLC::IPLCEvent *PLC::IPLC::pPLCEvent = NULL;
int PLC::IPLC::nRefCnt = 0;

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// 대화 상자 데이터입니다.
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.

// 구현입니다.
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()


// CEQPLCDlg 대화 상자
CEQPLCDlg::CEQPLCDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CEQPLCDlg::IDD, pParent)
{
	m_bvisible = FALSE;
	m_nIconNo  = 0; //TrayIcon 변경
	m_bPLCConnect = FALSE;
	m_bInit = FALSE;
	m_pPLCSignalCommand = NULL;
	m_pPLCSigWordCommand = NULL;
	m_pPLCSigWordCommand3 = NULL;

	// ProcessCommand Test
	m_pPLCSigWordCommandTest = NULL;

	m_pCassetteInfoCommand1 = NULL;
	m_pCassetteInfoCommand2 = NULL;
	m_nKeepAlive = 0;
	m_bEQOnline = FALSE;
	m_bSection = FALSE;
	m_hIcon = AfxGetApp()->LoadIcon(IDI_MAINEQPLC);

	m_strPCTag[0] = "PC_Alive";
	m_strPCTag[1] = "DatetimeSetCmd";
	m_strPCTag[2] = "EquipmentCtrlCmd";
    m_strPCTag[3] = "ProcessPort1Cmd";
	m_strPCTag[4] = "ProcessPort2Cmd";
	m_strPCTag[5] = "ProcessPort3Cmd";
	m_strPCTag[6] = "ProcessPort4Cmd";
	m_strPCTag[7] = "OnlineModeCmd";
	m_strPCTag[8] = "TerminalMsgCmd";
	m_strPCTag[9] = "OpCallCmd";
	m_strPCTag[10] = "FlowCtrlCmd";
	m_strPCTag[11] = "PanelID1ReqEvtReply";
	m_strPCTag[12] = "PanelID2ReqEvtReply";
	m_strPCTag[13] = "PanelID3ReqEvtReply";
	m_strPCTag[14] = "PanelID4ReqEvtReply";
	m_strPCTag[15] = "ECInfoCmd";
	m_strPCTag[16] = "Port1EvtReply";
	m_strPCTag[17] = "Port2EvtReply";
	m_strPCTag[18] = "Port3EvtReply";
	m_strPCTag[19] = "Port4EvtReply";
	m_strPCTag[20] = "FlowRecipeEvtReply";
	m_strPCTag[21] = "Port1DupEvtReply";
	m_strPCTag[22] = "Port2DupEvtReply";
	m_strPCTag[23] = "Port3DupEvtReply";
	m_strPCTag[24] = "Port4DupEvtReply";
	m_strPCTag[25] = "UnitEvtReply_1";
	m_strPCTag[26] = "UnitEvtReply_2";
	m_strPCTag[27] = "UnitEvtReply_3";
	m_strPCTag[28] = "UnitEvtReply_4";
	m_strPCTag[29] = "UnitEvtReply_11";
	m_strPCTag[30] = "UnitEvtReply_12";
	m_strPCTag[31] = "UnitEvtReply_13";
	m_strPCTag[32] = "UnitEvtReply_14";

	m_strPLCTag[0] = "PLC_Alive";
	m_strPLCTag[1] = "DatetimeSetReply";
	m_strPLCTag[2] = "EquipmentCmdReply";
	m_strPLCTag[3] = "ProcessPort1CmdReply";
	m_strPLCTag[4] = "ProcessPort2CmdReply";
	m_strPLCTag[5] = "ProcessPort3CmdReply";
	m_strPLCTag[6] = "ProcessPort4CmdReply";
	m_strPLCTag[7] = "Reserved_7";
	m_strPLCTag[8] = "TerminalMsgCmdReply";
	m_strPLCTag[9] = "OpCallCmdReply";
	m_strPLCTag[10] = "FlowCtrlCmdReply";
	m_strPLCTag[11] = "PanelID1ReqEvt";
	m_strPLCTag[12] = "PanelID2ReqEvt";
	m_strPLCTag[13] = "PanelID3ReqEvt";
	m_strPLCTag[14] = "PanelID4ReqEvt";
	m_strPLCTag[15] = "ECInfoCmdReply";
	m_strPLCTag[16] = "Port1Evt";
	m_strPLCTag[17] = "Port2Evt";
	m_strPLCTag[18] = "Port3Evt";
	m_strPLCTag[19] = "Port4Evt";
	m_strPLCTag[20] = "FlowRecipeEvt";
	m_strPLCTag[21] = "Port1DupEvt";
	m_strPLCTag[22] = "Port2DupEvt";
	m_strPLCTag[23] = "Port3DupEvt";
	m_strPLCTag[24] = "Port4DupEvt";
	m_strPLCTag[25] = "UnitEvtReport_1";
	m_strPLCTag[26] = "UnitEvtReport_2";
	m_strPLCTag[27] = "UnitEvtReport_3";
	m_strPLCTag[28] = "UnitEvtReport_4";
	m_strPLCTag[29] = "UnitEvtReport_11";
	m_strPLCTag[30] = "UnitEvtReport_12";
	m_strPLCTag[31] = "UnitEvtReport_13";
	m_strPLCTag[32] = "UnitEvtReport_14";
	m_stCommonState.nByWho = 0;
	//memset(&m_stCommonState,0x00,sizeof(m_stCommonState));
}

CEQPLCDlg::~CEQPLCDlg()
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("==== Application End ===="));
	CUtil::WriteLogFile(CABConfig::g_strStateLog, _T("==== Application End ===="));

	CABConfig::free();
	for_each(m_vtEQPLC.begin(), m_vtEQPLC.end(), DeleteAllObject());
	m_vtEQPLC.erase(remove(m_vtEQPLC.begin(), m_vtEQPLC.end(), static_cast<PLC::IPLC *>(0)), m_vtEQPLC.end());	
	for_each(m_dqDataChange.begin(), m_dqDataChange.end(), DeleteAllObject());
	m_dqDataChange.erase(remove(m_dqDataChange.begin(), m_dqDataChange.end(), static_cast<DATA_CHANGE *>(0)), m_dqDataChange.end());
	
	for_each(m_dqEQCommand.begin(), m_dqEQCommand.end(), DeleteAllObject());
	m_dqEQCommand.erase(remove(m_dqEQCommand.begin(), m_dqEQCommand.end(), static_cast<DATA_MESSAGE *>(0)), m_dqEQCommand.end());
}

void CEQPLCDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_LIST_PC, m_ctrlListPC);
	DDX_Control(pDX, IDC_LIST_PLC, m_ctrlListPLC);
}

BEGIN_MESSAGE_MAP(CEQPLCDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_WM_TIMER()
	ON_MESSAGE(WM_EVENT_GLASS_REQ, OnGlassInfoReq)
	ON_MESSAGE(WM_EVENT_SIGNAL_BIT, OnSignalBit)
	ON_MESSAGE(WM_EVENT_SIGNAL_WORD1, OnSignalWord1)
	ON_MESSAGE(WM_EVENT_SIGNAL_WORD3, OnSignalWord3)
	//ProcessCommandTest
	ON_MESSAGE(WM_EVENT_SIGNAL_WORD1_TEST, OnSignalWord1Test)
	//
	ON_MESSAGE(WM_EVENT_PANELIDL_INFO, OnPanelIDInfo)
	ON_MESSAGE(WM_EVENT_CASSETTE_INFO1, OnCassetteInfo1)
	ON_MESSAGE(WM_EVENT_CASSETTE_INFO2, OnCassetteInfo2)
	ON_MESSAGE(WM_EVENT_CASSETTE_INFO3, OnCassetteInfo3)
	ON_MESSAGE(WM_EVENT_CASSETTE_INFO4, OnCassetteInfo4)
	ON_MESSAGE(WM_EVENT_TRAY_ICON, OnTrayIcon)
	ON_MESSAGE(WMU_LC_EVENT,OnLC)
	ON_MESSAGE(WM_EVENT_PORT, OnPortEvent)
	ON_BN_CLICKED(IDCANCEL, &CEQPLCDlg::OnBnClickedCancel)
	ON_BN_CLICKED(IDC_RADIO_MANUAL, &CEQPLCDlg::OnBnClickedRadioManual)
	ON_BN_CLICKED(IDC_RADIO_AUTO, &CEQPLCDlg::OnBnClickedRadioAuto)
	ON_BN_CLICKED(IDC_BUTTON_PORT1_ON, &CEQPLCDlg::OnBnClickedButtonPort1On)
	ON_BN_CLICKED(IDC_BUTTON_PORT1_OFF, &CEQPLCDlg::OnBnClickedButtonPort1Off)
	ON_BN_CLICKED(IDC_BUTTON_PORT2_ON, &CEQPLCDlg::OnBnClickedButtonPort2On)
	ON_BN_CLICKED(IDC_BUTTON_PORT2_OFF, &CEQPLCDlg::OnBnClickedButtonport2Off)
	ON_BN_CLICKED(IDC_BUTTON_PORT3_ON, &CEQPLCDlg::OnBnClickedButtonPort3On)
	ON_BN_CLICKED(IDC_BUTTON_PORT3_OFF, &CEQPLCDlg::OnBnClickedButtonPort3Off)
	ON_BN_CLICKED(IDC_BUTTON_PORT4_ON, &CEQPLCDlg::OnBnClickedButtonPort4On)
	ON_BN_CLICKED(IDC_BUTTON_PORT4_OFF, &CEQPLCDlg::OnBnClickedButtonport4Off)
	ON_COMMAND(ID_END, &CEQPLCDlg::OnCloseProgram)
	ON_COMMAND(ID_BINARY_LOG, &CEQPLCDlg::OnBinaryLogOn)
	ON_COMMAND(ID_XML_LOG, &CEQPLCDlg::OnXMLLogOn)
	ON_WM_WINDOWPOSCHANGING()
	ON_BN_CLICKED(IDC_BUTTON_ONOFF, &CEQPLCDlg::OnBnClickedButtonOnoff)
END_MESSAGE_MAP()


// CEQPLCDlg 메시지 처리기

BOOL CEQPLCDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// 시스템 메뉴에 "정보..." 메뉴 항목을 추가합니다.

	// IDM_ABOUTBOX는 시스템 명령 범위에 있어야 합니다.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// 이 대화 상자의 아이콘을 설정합니다. 응용 프로그램의 주 창이 대화 상자가 아닐 경우에는
	//  프레임워크가 이 작업을 자동으로 수행합니다.
	SetIcon(m_hIcon, TRUE);			// 큰 아이콘을 설정합니다.
	SetIcon(m_hIcon, FALSE);		// 작은 아이콘을 설정합니다.

	if(!m_bSection)
	{
		InitializeCriticalSection(&m_stCriticalSection);
		m_bSection = TRUE;
	}

	//PC Signal 정보
	CRect rect;
	m_ctrlListPC.GetClientRect(&rect);
	m_ctrlListPC.InsertColumn(0, _T("Signal Name"), LVCFMT_CENTER, rect.Width()-50);
	m_ctrlListPC.InsertColumn(1, _T("Value"), LVCFMT_CENTER, 50);
	for(int i=0; i<33; i++)
	{
		m_ctrlListPC.InsertItem(i, m_strPCTag[i]);
		m_ctrlListPC.SetItemText(i,1, "0");
	}
	m_ctrlListPC.SetExtendedStyle(LVS_EX_FULLROWSELECT|LVS_EX_GRIDLINES);

	//PLC Signal 정보
	m_ctrlListPLC.GetClientRect(&rect);
	m_ctrlListPLC.InsertColumn(0, _T("Signal Name"), LVCFMT_CENTER, rect.Width()-50);
	m_ctrlListPLC.InsertColumn(1, _T("Value"), LVCFMT_CENTER, 50);
	for(int i=0; i<33; i++)
	{
		m_ctrlListPLC.InsertItem(i, m_strPLCTag[i]);
		m_ctrlListPLC.SetItemText(i,1, "0");
		
	}
	m_ctrlListPLC.SetExtendedStyle(LVS_EX_FULLROWSELECT|LVS_EX_GRIDLINES);


	CABConfig::load("D:\\T8-2 CCS Project\\Run\\EQPLC\\ini.xml");

	CUtil::WriteLogFile(CABConfig::g_strLog, _T("==== Application Start ===="));
	CUtil::WriteLogFile(CABConfig::g_strStateLog, _T("==== Application Start ===="));

	PLC::IPLC::pPLCEvent = this;
	LoadInfo();     
	LoadPLCInfo();  //Tag정보 가져오기

	CString strHostIP;
	int nRate;

	m_strEQName = CABConfig::g_strEQ1Caption;
	m_strEQIP = CABConfig::g_strPLC1IP;
	strHostIP = CABConfig::g_strLocalIP;
	nRate = CABConfig::g_nLocalRate;
	m_LCIFDlg.m_sIP = CABConfig::g_strLCIP;
	m_LCIFDlg.m_nPort = CABConfig::g_nLCPort;

	m_objEIP.SetEventParent(this);
	m_objEIP.SetHostIP((char *)strHostIP.operator LPCTSTR());
	m_objEIP.SetRate(nRate);
	m_LCIFDlg.Create((CWnd*)this);

	/*for(int i=0; i< m_vtEQPLC.size(); i++)
	{
		m_vtEQPLC[i]->SetOnline(TRUE);
	}*/
	CABConfig::g_bTerminalSignal;
	CABConfig::g_bOPCallSignal;
	CABConfig::g_bTerminalSignal_PLC;
	CABConfig::g_bOPCallSignal_PLC;

	m_nCount = 0;
	m_nResult = 0;

	m_LCIFDlg.Start();
	m_objEIP.Init();

	CreateTrayIcon("PLC");
	Start_Thread();
	
	SetTimer(0, 2000, NULL);

	// EQ1
	//SetTimer(1, CABConfig::g_nKeepAlive, NULL);

	//GetDlgItem(IDC_CORENETLIBCTRL1)->ShowWindow(SW_HIDE);
	m_LCIFDlg.ShowWindow(SW_SHOW);

	SetTimer(3, 4000, NULL);
	// Tray Icon
	SetTimer(18, 500, NULL);

	// Log자동삭제
	SetTimer(19, 3600000, NULL);

	CheckRadioButton(IDC_RADIO_MANUAL, IDC_RADIO_AUTO, IDC_RADIO_AUTO);
	OnBnClickedRadioAuto();

	return TRUE;  // 포커스를 컨트롤에 설정하지 않으면 TRUE를 반환합니다.
}

void CEQPLCDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// 대화 상자에 최소화 단추를 추가할 경우 아이콘을 그리려면
//  아래 코드가 필요합니다. 문서/뷰 모델을 사용하는 MFC 응용 프로그램의 경우에는
//  프레임워크에서 이 작업을 자동으로 수행합니다.

void CEQPLCDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // 그리기를 위한 디바이스 컨텍스트

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// 클라이언트 사각형에서 아이콘을 가운데에 맞춥니다.
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// 아이콘을 그립니다.
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// 사용자가 최소화된 창을 끄는 동안에 커서가 표시되도록 시스템에서
//  이 함수를 호출합니다.
HCURSOR CEQPLCDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

//////////////////////////////////////////////////////////////////////////////
//	Ethernet/IP Event
///////////////////////////////////////////////////////////////////////////////
void CEQPLCDlg::StatusEventProduced(int nVarId, BOOL bOnline)
{
	CUtil::WriteLogFile(CABConfig::g_strStateLog, _T("Status Produced - ID : %d / %s / %s"),
						nVarId, bOnline ? _T("Online") : _T("Offline"), m_vtEQPLC[nVarId]->GetTagName());

	m_vtEQPLC[nVarId]->SetOnline(bOnline);
}

void CEQPLCDlg::StatusEventConsumed(int nVarId, BOOL bOnline)
{
	CUtil::WriteLogFile(CABConfig::g_strStateLog, _T("Status Consumed - ID : %d / %s / %s"),
						nVarId, bOnline ? _T("Online") : _T("Offline"), m_vtEQPLC[nVarId]->GetTagName());

	m_vtEQPLC[nVarId]->SetOnline(bOnline);
}

void CEQPLCDlg::DataChangeEvent(const char *szTagName, int nVarID, char *pData)
{
	//CUtil::WriteLogFile(CABConfig::g_strLog, _T("DataChangeEvent - Name : %s / VarID : %d"), szTagName, nVarID);

	if(nVarID > m_vtEQPLC.size() || nVarID < 0) 
		return;

	DATA_CHANGE* pstDataChange = new DATA_CHANGE;
	pstDataChange->strTagName = szTagName;
	pstDataChange->nVarID = nVarID;

	memcpy(pstDataChange->szData, pData, sizeof(pstDataChange->szData));
	::EnterCriticalSection(&m_stCriticalSection);
	m_dqDataChange.push_back(pstDataChange);
	::LeaveCriticalSection(&m_stCriticalSection);
}

void CEQPLCDlg::DataMessageChangeEvent(int nPLCNo, int nNum, CString strTerminal, CString strOPCall)
{
	//CUtil::WriteLogFile(CABConfig::g_strLog, _T("DataChangeEvent - Name : %s / VarID : %d"), szTagName, nVarID);

	DATA_MESSAGE* pstDataMessage = new DATA_MESSAGE;
	pstDataMessage->nPLCNo = nPLCNo;
	pstDataMessage->nNum = nNum;
	pstDataMessage->strTerminal = strTerminal;
	pstDataMessage->strOPCall = strOPCall;

	::EnterCriticalSection(&m_stCriticalSection);
	m_dqEQCommand.push_back(pstDataMessage);
	::LeaveCriticalSection(&m_stCriticalSection);
}

void CEQPLCDlg::ThreadFunc()
{

	CString strBuf;
	int nGrade[8];
	char szBuf[255];
	char szBuf2[255];
	char szValue[255];
	int nCount=0;
	
	DATA_CHANGE* pstDataChange = NULL;
	DATA_MESSAGE* pstDataMessage = NULL;
	while(1)
	{
		if( ::WaitForSingleObject(m_hThread, 100) == WAIT_OBJECT_0 )
		{
			return;
		}

		if(CABConfig::g_bTerminalSignal == FALSE && CABConfig::g_bOPCallSignal == FALSE)
		{
			if(CABConfig::g_bTerminalSignal_PLC == FALSE && CABConfig::g_bOPCallSignal_PLC == FALSE)
			{
				if(!m_dqEQCommand.empty())
				{
					::EnterCriticalSection(&m_stCriticalSection);
					pstDataMessage = m_dqEQCommand[0];
					m_dqEQCommand.pop_front();
					::LeaveCriticalSection(&m_stCriticalSection);
					DataMessageChange(pstDataMessage->nPLCNo,pstDataMessage->nNum,pstDataMessage->strTerminal,pstDataMessage->strOPCall);
					if(NULL != pstDataMessage)
					{
						delete pstDataMessage;
						pstDataMessage = NULL;
					}				
				}
			}
		}		

		//	로더부에서 발행 데이터 생성이 여러게 왔을시 나중에 처리
		while(!m_dqDataChange.empty())
		{
			::EnterCriticalSection(&m_stCriticalSection);
			pstDataChange = m_dqDataChange[0];
			m_dqDataChange.pop_front();
			::LeaveCriticalSection(&m_stCriticalSection);

			if(1 == CABConfig::g_nBinary)
			{
				CUtil::WriteLogFile(CABConfig::g_strBinaryLog, "%s : %d ======================================================",
									pstDataChange->strTagName, pstDataChange->nVarID);
				int *lpData = (int *) pstDataChange->szData;				
				if(pstDataChange->strTagName == "C_01_SIGEVENT")
				{
					/*CUtil::WriteLogFile(CABConfig::g_strLog, "PLC OPCALL MESSAG : %d",pstDataChange->szData[1]);*/			
					memcpy(&nGrade[0], &pstDataChange->szData[0],32);
					memset(szBuf, 0x00, sizeof(szBuf));
					_itoa(nGrade[0], &szBuf[0], 2);
					memset(szBuf2, 0x00, sizeof(szBuf2));
					wsprintf(szBuf2, "%032s", szBuf);
					CUtil::ABPLCBinSwap(szBuf2, strlen(szBuf2));
					memset(szValue, 0x00, sizeof(szValue));
					strcpy(&szValue[0], szBuf2);
					memset(szBuf, 0x00, sizeof(szBuf));
					_itoa(nGrade[1], &szBuf[0], 2);
					memset(szBuf2, 0x00, sizeof(szBuf2));
					wsprintf(szBuf2, "%032s", szBuf);
					CUtil::ABPLCBinSwap(szBuf2, strlen(szBuf2));
					strcpy(&szValue[32], szBuf2);
					for(int j=0; j<29; j++)
					{
							if(nCount == 16)
								nCount +=2;
							else
								if(nCount == 22)
									nCount +=1;
								else
									if(nCount == 28)
										nCount += 4;
									else
										if(nCount == 36)
											nCount +=6;
						strBuf.Format(_T("%c"),szValue[nCount]);
						m_ctrlListPLC.SetItemText(j,1, strBuf);
						nCount+=1;	
					}
					nCount=0;
				}
				for(int i = 0; i < 125; i += 11)
				{
					CUtil::WriteLogFile(CABConfig::g_strBinaryLog, "%08X %08X %08X %08X %08X %08X %08X %08X %08X %08X %08X",
						lpData[i], lpData[i+1], lpData[i+2], lpData[i+3], lpData[i+4], lpData[i+5], lpData[i+6], lpData[i+7],
						lpData[i+8], lpData[i+9], lpData[i+10]);
				}
			}
			m_vtEQPLC[pstDataChange->nVarID]->SetData(pstDataChange->strTagName, pstDataChange->szData);
			if(NULL != pstDataChange)
			{
				delete pstDataChange;
				pstDataChange = NULL;
			}
		}
	}
}


void CEQPLCDlg::EventSignalBitDataSend(int nPLCNo)
{
	TRACE("EventSignalBitDataSend - PLCNo=%d\n", nPLCNo);
	PostMessage(WM_EVENT_SIGNAL_BIT, (WPARAM) nPLCNo, (LPARAM) m_pPLCSignalCommand->GetVarID());
}

void CEQPLCDlg::EventSigWordData1Send(int nPLCNo)
{
	TRACE("EventSigWordData1Send - PLCNo=%d\n", nPLCNo);
	PostMessage(WM_EVENT_SIGNAL_WORD1, (WPARAM) nPLCNo, (LPARAM) m_pPLCSigWordCommand->GetVarID());
}

void CEQPLCDlg::EventSigWordData1SendTest(int nPLCNo)
{
	TRACE("EventSigWordData1SendTest - PLCNo=%d\n", nPLCNo);
	PostMessage(WM_EVENT_SIGNAL_WORD1_TEST, (WPARAM) nPLCNo, (LPARAM) m_pPLCSigWordCommandTest->GetVarID());
}

void CEQPLCDlg::EventSigWordData3Send(int nPLCNo)
{
	TRACE("EventSigWordData3Send - PLCNo=%d\n", nPLCNo);
	PostMessage(WM_EVENT_SIGNAL_WORD3, (WPARAM) nPLCNo, (LPARAM) m_pPLCSigWordCommand3->GetVarID());
}

void CEQPLCDlg::EventSigPanelIDInfo(int PortNo)
{
	PostMessage(WM_EVENT_PANELIDL_INFO, (WPARAM) PortNo, (LPARAM) m_pPLCPanelIDInfo->GetVarID());
}

void CEQPLCDlg::EventCassetteInfoSend1(int nPLCNo)
{
	TRACE("EventCassetteInfoSend - PLCNo=%d\n", nPLCNo);
	PostMessage(WM_EVENT_CASSETTE_INFO1,(WPARAM) nPLCNo, (LPARAM) m_pCassetteInfoCommand1->GetVarID());
}

void CEQPLCDlg::EventCassetteInfoSend2(int nPLCNo)
{
	TRACE("EventCassetteInfoSend - PLCNo=%d\n", nPLCNo);
	PostMessage(WM_EVENT_CASSETTE_INFO2, (WPARAM) nPLCNo, (LPARAM) m_pCassetteInfoCommand2->GetVarID());
}

void CEQPLCDlg::EventCassetteInfoSend3(int nPLCNo)
{
	TRACE("EventCassetteInfoSend - PLCNo=%d\n", nPLCNo);
	PostMessage(WM_EVENT_CASSETTE_INFO3, (WPARAM) nPLCNo, (LPARAM) m_pCassetteInfoCommand3->GetVarID());
}

void CEQPLCDlg::EventCassetteInfoSend4(int nPLCNo)
{
	TRACE("EventCassetteInfoSend - PLCNo=%d\n", nPLCNo);
	PostMessage(WM_EVENT_CASSETTE_INFO4, (WPARAM) nPLCNo, (LPARAM) m_pCassetteInfoCommand4->GetVarID());
}

void CEQPLCDlg::EventSignalPLCAlive(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Command = PLC Alive - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Command = PLC Alive - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));
	m_ctrlLogList.AddString(m_strLog);*/

	m_nKeepAlive = CABConfig::g_nKeepAlive;
}

void CEQPLCDlg::EventSignalDatetimeSet(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Command = Datetime - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));
	
	/*m_strLog.Format(_T("Signal Command = Datetime - PLCNo=%d / Signal=FALSE"), nPLCNo);
	m_ctrlLogList.AddString(m_strLog);*/
	if(bSet == TRUE)
	{
		CMsgPLCSignalEvent *pMsg = new CMsgPLCSignalEvent();
		pMsg->m_nPort = 0;
		pMsg->m_nSigID = 4;
		pMsg->m_nResult = bSet;
		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "L/A");
		m_LCIFDlg.OnPLCEvent(msg);
		m_pPLCSignalCommand->EventSignalDatetimeSet(FALSE);
	}	
}

void CEQPLCDlg::EventSignalEquipmentCmd(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Command = Equipment Command - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));
	
	/*m_strLog.Format(_T("Signal Command = Equipment Command - PLCNo=%d / Signal=FALSE"), nPLCNo);
	m_ctrlLogList.AddString(m_strLog);*/

	if(bSet == TRUE)
	{
		CMsgPLCSignalEvent *pMsg = new CMsgPLCSignalEvent();
		pMsg->m_nPort = 0;
		pMsg->m_nSigID = 3;
		pMsg->m_nResult = bSet;
		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "L/A");
		m_LCIFDlg.OnPLCEvent(msg);
		m_pPLCSignalCommand->EventSignalEquipmentCmd(FALSE);
	}	
}

void CEQPLCDlg::EventSignalFlowCtrlCmd(int nPLCNo)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Command = Flow Control Command - PLCNo=%d / Signal=FALSE"), nPLCNo);
	m_pPLCSignalCommand->EventSignalFlowCtrlCmd(FALSE);
}

void CEQPLCDlg::EventSignalProcessPort1Cmd(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Command = ProcessPort1 Command - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Command = ProcessPort1 Command - PLCNo=%d / Signal=FALSE"), nPLCNo);
	m_ctrlLogList.AddString(m_strLog);*/
	
	if(bSet == TRUE)
	{
		CMsgPLCSignalEvent *pMsg = new CMsgPLCSignalEvent();
		pMsg->m_nPort = 1;
		pMsg->m_nSigID = 1;
		pMsg->m_nResult = bSet;
		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "Unit#01");
		m_LCIFDlg.OnPLCEvent(msg);
		m_pPLCSignalCommand->EventSignalProcessPort1Cmd(FALSE);
	}
}
void CEQPLCDlg::EventSignalProcessPort2Cmd(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Command = ProcessPort2 Command - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Command = ProcessPort1 Command - PLCNo=%d / Signal=FALSE"), nPLCNo);
	m_ctrlLogList.AddString(m_strLog);*/

	if(bSet == TRUE)
	{	
		CMsgPLCSignalEvent *pMsg = new CMsgPLCSignalEvent();
		pMsg->m_nPort = 2;
		pMsg->m_nSigID = 1;
		pMsg->m_nResult = bSet;
		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "Unit#02");
		m_LCIFDlg.OnPLCEvent(msg);	
		m_pPLCSignalCommand->EventSignalProcessPort2Cmd(FALSE);
	}	
}
void CEQPLCDlg::EventSignalProcessPort3Cmd(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Command = ProcessPort3 Command - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Command = ProcessPort1 Command - PLCNo=%d / Signal=FALSE"), nPLCNo);
	m_ctrlLogList.AddString(m_strLog);*/

	if(bSet == TRUE)
	{	
		CMsgPLCSignalEvent *pMsg = new CMsgPLCSignalEvent();
		pMsg->m_nPort = 3;
		pMsg->m_nSigID = 1;
		pMsg->m_nResult = bSet;
		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "Unit#03");
		m_LCIFDlg.OnPLCEvent(msg);
		m_pPLCSignalCommand->EventSignalProcessPort3Cmd(FALSE);
	}	
}
void CEQPLCDlg::EventSignalProcessPort4Cmd(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Command = ProcessPort4 Command - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Command = ProcessPort1 Command - PLCNo=%d / Signal=FALSE"), nPLCNo);
	m_ctrlLogList.AddString(m_strLog);*/

	if(bSet == TRUE)
	{	
		CMsgPLCSignalEvent *pMsg = new CMsgPLCSignalEvent();
		pMsg->m_nPort = 4;
		pMsg->m_nSigID = 1;
		pMsg->m_nResult = bSet;
		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "Unit#04");
		m_LCIFDlg.OnPLCEvent(msg);
		m_pPLCSignalCommand->EventSignalProcessPort4Cmd(FALSE);
	}	
}
void CEQPLCDlg::EventSignalPCData1Cmd(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strTestLog, _T("Signal Command = ProcessPort1 Command - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Command = ProcessPort1 Command - PLCNo=%d / Signal=FALSE"), nPLCNo);
	m_ctrlLogList.AddString(m_strLog);*/

	if(bSet == TRUE)
	{	
		m_pPLCSignalCommand->EventSignalPCData1(FALSE);
	}	
}
void CEQPLCDlg::EventSignalPCData2Cmd(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strTestLog, _T("Signal Command = ProcessPort2 Command - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Command = ProcessPort1 Command - PLCNo=%d / Signal=FALSE"), nPLCNo);
	m_ctrlLogList.AddString(m_strLog);*/

	if(bSet == TRUE)
	{	
		m_pPLCSignalCommand->EventSignalPCData2(FALSE);
	}	
}
void CEQPLCDlg::EventSignalPCData3Cmd(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strTestLog, _T("Signal Command = ProcessPort3 Command - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Command = ProcessPort1 Command - PLCNo=%d / Signal=FALSE"), nPLCNo);
	m_ctrlLogList.AddString(m_strLog);*/

	if(bSet == TRUE)
	{	
		m_pPLCSignalCommand->EventSignalPCData3(FALSE);
	}	
}
void CEQPLCDlg::EventSignalPCData4Cmd(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strTestLog, _T("Signal Command = ProcessPort4 Command - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Command = ProcessPort1 Command - PLCNo=%d / Signal=FALSE"), nPLCNo);
	m_ctrlLogList.AddString(m_strLog);*/

	if(bSet == TRUE)
	{	
		m_pPLCSignalCommand->EventSignalPCData4(FALSE);
	}	
}
void CEQPLCDlg::EventSignalTerminalMsgCmd(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("PLC Signal Command = Terminal Message - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));
	
	/*m_strLog.Format(_T("Signal Command = Terminal Message - PLCNo=%d / Signal=FALSE"), nPLCNo);
	m_ctrlLogList.AddString(m_strLog);*/

	if(bSet == TRUE)
	{
		CMsgPLCSignalEvent *pMsg = new CMsgPLCSignalEvent();
		pMsg->m_nPort = 0;
		pMsg->m_nSigID = 5;
		pMsg->m_nResult = bSet;
		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "L/A");
		m_LCIFDlg.OnPLCEvent(msg);
		m_pPLCSignalCommand->EventSignalTerminalMsgCmd(FALSE);
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("PC Teminal Message Signal : FALSE"));
	}
}

void CEQPLCDlg::EventSignalOPCallCmd(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("PLC Signal Command = Operator Call - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));
	
	/*m_strLog.Format(_T("Signal Command = Operator Call - PLCNo=%d / Signal=FALSE"), nPLCNo);
	m_ctrlLogList.AddString(m_strLog);*/

	if(bSet == TRUE)
	{
		CMsgPLCSignalEvent *pMsg = new CMsgPLCSignalEvent();
		pMsg->m_nPort = 0;
		pMsg->m_nSigID = 6;
		pMsg->m_nResult = bSet;
		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "L/A");
		m_LCIFDlg.OnPLCEvent(msg);
		m_pPLCSignalCommand->EventSignalOPCallCmd(FALSE);
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("PC OPCall Message Signal : FALSE"));
	}
}

void CEQPLCDlg::EventSignalPort1State(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event = SignalPort1State - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	if(bSet == TRUE)
	{
		CMsgPortPauseEvent *pMsg = new CMsgPortPauseEvent();

		pMsg->m_nPort = 1;

		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "Unit#01");
		m_LCIFDlg.OnPLCEvent(msg);
	}
	else
	{
		CMsgPortResumeEvent *pMsg = new CMsgPortResumeEvent();

		pMsg->m_nPort = 1;

		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "Unit#01");
		m_LCIFDlg.OnPLCEvent(msg);
	}
}

void CEQPLCDlg::EventSignalPort2State(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event = SignalPort2State - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	if(bSet == TRUE)
	{
		CMsgPortPauseEvent *pMsg = new CMsgPortPauseEvent();

		pMsg->m_nPort = 2;

		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "Unit#02");
		m_LCIFDlg.OnPLCEvent(msg);
	}
	else
	{
		CMsgPortResumeEvent *pMsg = new CMsgPortResumeEvent();

		pMsg->m_nPort = 2;

		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "Unit#02");
		m_LCIFDlg.OnPLCEvent(msg);
	}
}

void CEQPLCDlg::EventSignalPort3State(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event = SignalPort3State - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	if(bSet == TRUE)
	{
		CMsgPortPauseEvent *pMsg = new CMsgPortPauseEvent();

		pMsg->m_nPort = 3;

		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "Unit#03");
		m_LCIFDlg.OnPLCEvent(msg);
	}
	else
	{
		CMsgPortResumeEvent *pMsg = new CMsgPortResumeEvent();

		pMsg->m_nPort = 3;

		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "Unit#03");
		m_LCIFDlg.OnPLCEvent(msg);
	}
}

void CEQPLCDlg::EventSignalPort4State(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event = SignalPort4State - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	if(bSet == TRUE)
	{
		CMsgPortPauseEvent *pMsg = new CMsgPortPauseEvent();

		pMsg->m_nPort = 4;

		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "Unit#04");
		m_LCIFDlg.OnPLCEvent(msg);
	}
	else
	{
		CMsgPortResumeEvent *pMsg = new CMsgPortResumeEvent();

		pMsg->m_nPort = 4;

		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "Unit#04");
		m_LCIFDlg.OnPLCEvent(msg);
	}
}

void CEQPLCDlg::EventSignalPort1InitReq(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event = SignalPort1InitReq - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	m_pPLCSignalCommand->EventSignalPort1InitReqEvt(bSet);

	if(FALSE == bSet)
		return;

	CMsgPortInitReqEvent *pMsg = new CMsgPortInitReqEvent();

	pMsg->m_nPort = 1;

	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, "Unit#01");
	m_LCIFDlg.OnPLCEvent(msg);
}

void CEQPLCDlg::EventSignalPort2InitReq(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event = SignalPort2InitReq - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	m_pPLCSignalCommand->EventSignalPort2InitReqEvt(bSet);

	if(FALSE == bSet)
		return;

	CMsgPortInitReqEvent *pMsg = new CMsgPortInitReqEvent();

	pMsg->m_nPort = 2;

	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, "Unit#02");
	m_LCIFDlg.OnPLCEvent(msg);
}

void CEQPLCDlg::EventSignalPort3InitReq(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event = SignalPort3InitReq - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	m_pPLCSignalCommand->EventSignalPort3InitReqEvt(bSet);

	if(FALSE == bSet)
		return;

	CMsgPortInitReqEvent *pMsg = new CMsgPortInitReqEvent();

	pMsg->m_nPort = 3;

	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, "Unit#03");
	m_LCIFDlg.OnPLCEvent(msg);
}

void CEQPLCDlg::EventSignalPort4InitReq(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event = SignalPort4InitReq - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	m_pPLCSignalCommand->EventSignalPort4InitReqEvt(bSet);

	if(FALSE == bSet)
		return;

	CMsgPortInitReqEvent *pMsg = new CMsgPortInitReqEvent();

	pMsg->m_nPort = 4;

	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, "Unit#04");
	m_LCIFDlg.OnPLCEvent(msg);
}

void CEQPLCDlg::EventSignalPanelID1ReqEvt(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event = PanelID1 Request - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Event = PanelID1 Request - PLCNo=%d / Signal=%s "), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));
	m_ctrlLogList.AddString(m_strLog);*/

	if(FALSE == bSet)
	{
		CMsgPLCSignalEvent *pMsg = new CMsgPLCSignalEvent();
		pMsg->m_nPort = 1;
		pMsg->m_nSigID = 2;
		pMsg->m_nResult = bSet;
		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "Unit#01");
		m_LCIFDlg.OnPLCEvent(msg);
		m_pPLCSignalCommand->EventSignalPanelID1ReqEvt(bSet);
		return;
	}

	CMsgPanelIDEvent* pMsg = new CMsgPanelIDEvent();

	pMsg->m_nPort = 1;

	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, "Unit#01");
	m_LCIFDlg.OnPLCEvent(msg);

}

void CEQPLCDlg::EventSignalPanelID2ReqEvt(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event = PanelID2 Request - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Event = PanelID2 Request - PLCNo=%d / Signal=%s "), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));
	m_ctrlLogList.AddString(m_strLog);*/

	if(FALSE == bSet)
	{
		CMsgPLCSignalEvent *pMsg = new CMsgPLCSignalEvent();
		pMsg->m_nPort = 2;
		pMsg->m_nSigID = 2;
		pMsg->m_nResult = bSet;
		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "Unit#02");
		m_LCIFDlg.OnPLCEvent(msg);
		m_pPLCSignalCommand->EventSignalPanelID2ReqEvt(bSet);
		return;
	}


	CMsgPanelIDEvent* pMsg = new CMsgPanelIDEvent();

	pMsg->m_nPort = 2;

	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, "Unit#02");
	m_LCIFDlg.OnPLCEvent(msg);

}

void CEQPLCDlg::EventSignalPanelID3ReqEvt(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event = PanelID3 Request - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Event = PanelID3 Request - PLCNo=%d / Signal=%s "), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));
	m_ctrlLogList.AddString(m_strLog);*/

	
	if(FALSE == bSet)
	{
		CMsgPLCSignalEvent *pMsg = new CMsgPLCSignalEvent();
		pMsg->m_nPort = 3;
		pMsg->m_nSigID = 2;
		pMsg->m_nResult = bSet;
		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "Unit#03");
		m_LCIFDlg.OnPLCEvent(msg);
		m_pPLCSignalCommand->EventSignalPanelID3ReqEvt(bSet);
		return;
	}


	CMsgPanelIDEvent* pMsg = new CMsgPanelIDEvent();

	pMsg->m_nPort = 3;

	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, "Unit#03");
	m_LCIFDlg.OnPLCEvent(msg);

}

void CEQPLCDlg::EventSignalPanelID4ReqEvt(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event = PanelID4 Request - PLCNo=%d / Signal=%s"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Event = PanelID4 Request - PLCNo=%d / Signal=%s "), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"));
	m_ctrlLogList.AddString(m_strLog);*/

	
	if(FALSE == bSet)
	{
		CMsgPLCSignalEvent *pMsg = new CMsgPLCSignalEvent();
		pMsg->m_nPort = 4;
		pMsg->m_nSigID = 2;
		pMsg->m_nResult = bSet;
		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "Unit#04");
		m_LCIFDlg.OnPLCEvent(msg);
		m_pPLCSignalCommand->EventSignalPanelID4ReqEvt(bSet);
		return;
	}
	CMsgPanelIDEvent* pMsg = new CMsgPanelIDEvent();

	pMsg->m_nPort = 4;

	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, "Unit#04");
	m_LCIFDlg.OnPLCEvent(msg);

}

void CEQPLCDlg::ECInfoCmdReply(int nPLCNo)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Command = ECInfoCmd - PLCNo=%d / Signal=FALSE"), nPLCNo);

	/*m_strLog.Format(_T("Signal Command = ECInfoCmd - PLCNo=%d / Signal=FALSE"), nPLCNo);
	m_ctrlLogList.AddString(m_strLog);*/

	m_pPLCSignalCommand->EventSignalEQConstantCmd(FALSE);
}

void CEQPLCDlg::EventSignalFlowRecipe(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event = Flow Recipe/Group Event - PLCNo=%d / Signal=%s / EventID=%d"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"), m_nEventID);
	
	/*m_strLog.Format(_T("Signal Event = Flow Recipe/Group Event - PLCNo=%d / Signal=%s / EventID=%d"), nPLCNo, bSet ? _T("TRUE") : _T("FLASE"), m_nEventID);
	m_ctrlLogList.AddString(m_strLog);*/
	
	m_pPLCSignalCommand->EventSignalFlowRecipe(bSet);
	if(FALSE == bSet)	return;
	CXMLMsg msg;
	if(0 == m_nEventID)
	{
		CMsgFlowGroupEvent* pMsg = new CMsgFlowGroupEvent();

		pMsg->nEventID = m_nEventID;
		memcpy(pMsg->nOrder, m_nEQFlowGroup, sizeof(short) * 10);

		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "N/A");
		m_LCIFDlg.OnPLCEvent(msg);
	}
	else
	{
		if(0 >= m_nFlowRecipeNo)
		{
			TRACE("FlowRecipe Event : Recipe No = %d\n", m_nFlowRecipeNo);
			return;
		}

		CMsgFlowRecipeEvent* pMsg = new CMsgFlowRecipeEvent();

		pMsg->nEventID = m_nEventID;
//		pMsg->nFlowNo = m_nFlowRecipeNo;
		char szTime[32];
		CString strTime;

		memset(szTime, 0x00, sizeof(szTime));
		sprintf(szTime, "%04d%02d%02d%02d%02d%02d",
			m_nEQFlowRecipeBody[m_nFlowRecipeNo- 1].nYear, m_nEQFlowRecipeBody[m_nFlowRecipeNo- 1].nMonth,
			m_nEQFlowRecipeBody[m_nFlowRecipeNo- 1].nDay, m_nEQFlowRecipeBody[m_nFlowRecipeNo- 1].nHour,
			m_nEQFlowRecipeBody[m_nFlowRecipeNo- 1].nMinute, m_nEQFlowRecipeBody[m_nFlowRecipeNo- 1].nSecond);

		strTime = szTime;
		pMsg->Add(m_nEQFlowRecipeBody[m_nFlowRecipeNo - 1].szFlowID, m_nFlowRecipeNo,
			m_nEQFlowRecipeBody[m_nFlowRecipeNo - 1].nRevision, strTime,
			m_nEQFlowRecipeBody[m_nFlowRecipeNo - 1].nFlowBody);
		msg.Load(pMsg);
		msg.SetSource(m_strEQName, "N/A");
		m_LCIFDlg.OnPLCEvent(msg);
	}
}

void CEQPLCDlg::EventSignalPLCData1(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strTestLog, _T("Signal PLCData Event - PortNo=1 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));

	m_pPLCSignalCommand->EventSignalPLCData1(bSet);
	if(FALSE == bSet)	return;

	int nPortNo = 1;

	ProcessCommand stProcessCommand;

	PLCDataReq(nPLCNo, nPortNo, stProcessCommand);

	CUtil::WriteLogFile(CABConfig::g_strTestLog, _T("PLCData : PortNo= %d , CommandID = %d, ByWho = %d, CSTID = %s, Map_Stif = %d, Start_Stif = %d"),
		nPortNo, stProcessCommand.m_nCommandID,stProcessCommand.m_nByWho, stProcessCommand.m_strCSTID, stProcessCommand.m_nMap_Stif, stProcessCommand.m_nStart_Stif);
		
	/*CMsgPLCDataEvent* pMsg = new CMsgPLCDataEvent();

	pMsg->m_nPort = nPortNo;
	pMsg->m_nCommandID = stProcessCommand.m_nCommandID;
	pMsg->m_nByWho = stProcessCommand.m_nByWho;
	pMsg->m_strCSTID = stProcessCommand.m_strCSTID;
	pMsg->m_nMap_Stif = stProcessCommand.m_nMap_Stif;
	pMsg->m_nStart_Stif = stProcessCommand.m_nStart_Stif;

	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, "Unit#01");
	m_LCIFDlg.OnPLCEvent(msg);*/
}

void CEQPLCDlg::EventSignalPLCData2(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strTestLog, _T("Signal PLCData Event - PortNo=2 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));

	m_pPLCSignalCommand->EventSignalPLCData2(bSet);
	if(FALSE == bSet)	return;

	int nPortNo = 2;

	ProcessCommand stProcessCommand;

	PLCDataReq(nPLCNo, nPortNo, stProcessCommand);

	CUtil::WriteLogFile(CABConfig::g_strTestLog, _T("PLCData : PortNo= %d , CommandID = %d, ByWho = %d, CSTID = %s, Map_Stif = %d, Start_Stif = %d"),
		nPortNo, stProcessCommand.m_nCommandID,stProcessCommand.m_nByWho, stProcessCommand.m_strCSTID, stProcessCommand.m_nMap_Stif, stProcessCommand.m_nStart_Stif);

	//CMsgPLCDataEvent* pMsg = new CMsgPLCDataEvent();

	//pMsg->m_nPort = nPortNo;
	//pMsg->m_nCommandID = stProcessCommand.m_nCommandID;
	//pMsg->m_nByWho = stProcessCommand.m_nByWho;
	//pMsg->m_strCSTID = stProcessCommand.m_strCSTID;
	//pMsg->m_nMap_Stif = stProcessCommand.m_nMap_Stif;
	//pMsg->m_nStart_Stif = stProcessCommand.m_nStart_Stif;

	//CXMLMsg msg;
	//msg.Load(pMsg);
	//msg.SetSource(m_strEQName, "Unit#02");
	//m_LCIFDlg.OnPLCEvent(msg);
}

void CEQPLCDlg::EventSignalPLCData3(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strTestLog, _T("Signal PLCData Event - PortNo=3 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));

	m_pPLCSignalCommand->EventSignalPLCData3(bSet);
	if(FALSE == bSet)	return;

	int nPortNo = 3;

	ProcessCommand stProcessCommand;

	PLCDataReq(nPLCNo, nPortNo, stProcessCommand);

	CUtil::WriteLogFile(CABConfig::g_strTestLog, _T("PLCData : PortNo= %d , CommandID = %d, ByWho = %d, CSTID = %s, Map_Stif = %d, Start_Stif = %d"),
		nPortNo, stProcessCommand.m_nCommandID,stProcessCommand.m_nByWho, stProcessCommand.m_strCSTID, stProcessCommand.m_nMap_Stif, stProcessCommand.m_nStart_Stif);


	//CMsgPLCDataEvent* pMsg = new CMsgPLCDataEvent();

	//pMsg->m_nPort = nPortNo;
	//pMsg->m_nCommandID = stProcessCommand.m_nCommandID;
	//pMsg->m_nByWho = stProcessCommand.m_nByWho;
	//pMsg->m_strCSTID = stProcessCommand.m_strCSTID;
	//pMsg->m_nMap_Stif = stProcessCommand.m_nMap_Stif;
	//pMsg->m_nStart_Stif = stProcessCommand.m_nStart_Stif;

	//CXMLMsg msg;
	//msg.Load(pMsg);
	//msg.SetSource(m_strEQName, "Unit#03");
	//m_LCIFDlg.OnPLCEvent(msg);
}

void CEQPLCDlg::EventSignalPLCData4(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strTestLog, _T("Signal PLCData Event - PortNo=4 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));

	m_pPLCSignalCommand->EventSignalPLCData4(bSet);
	if(FALSE == bSet)	return;

	int nPortNo = 4;

	ProcessCommand stProcessCommand;

	PLCDataReq(nPLCNo, nPortNo, stProcessCommand);

	CUtil::WriteLogFile(CABConfig::g_strTestLog, _T("PLCData : PortNo= %d , CommandID = %d, ByWho = %d, CSTID = %s, Map_Stif = %d, Start_Stif = %d"),
		nPortNo, stProcessCommand.m_nCommandID,stProcessCommand.m_nByWho, stProcessCommand.m_strCSTID, stProcessCommand.m_nMap_Stif, stProcessCommand.m_nStart_Stif);

	//CMsgPLCDataEvent* pMsg = new CMsgPLCDataEvent();

	//pMsg->m_nPort = nPortNo;
	//pMsg->m_nCommandID = stProcessCommand.m_nCommandID;
	//pMsg->m_nByWho = stProcessCommand.m_nByWho;
	//pMsg->m_strCSTID = stProcessCommand.m_strCSTID;
	//pMsg->m_nMap_Stif = stProcessCommand.m_nMap_Stif;
	//pMsg->m_nStart_Stif = stProcessCommand.m_nStart_Stif;

	//CXMLMsg msg;
	//msg.Load(pMsg);
	//msg.SetSource(m_strEQName, "Unit#04");
	//m_LCIFDlg.OnPLCEvent(msg);
}

void CEQPLCDlg::PLCDataReq(int nPLCNo,int nPortNo, ProcessCommand &stProcessCommand)
{
	CString strTag;
	int nIndex = 192;
	char szBuf[20];
	unsigned char szBuf1[10];
	char *pData = NULL;

	INT32 nData[96];
	memset(nData, 0x00, sizeof(INT32) * 96);

	strTag = "U_01_PLCData";
	m_objEIP.receiveValues((char *)m_strEQIP.operator LPCTSTR(), (char *)strTag.operator LPCTSTR(), 0, nData, 96);

	pData = (char*)nData;

	switch(nPortNo)
	{
	case 1:
		nIndex +=0;
		//	CommandID
		memcpy(&stProcessCommand.m_nCommandID, &pData[nIndex], 2);
		nIndex += 2;

		// ByWho
		memcpy(&stProcessCommand.m_nByWho, &pData[nIndex], 2);
		nIndex += 2;

		//	Cassette ID
		memset(szBuf, 0x00, sizeof(szBuf));
		memcpy(szBuf, &pData[nIndex], 16);
		CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
		stProcessCommand.m_strCSTID = szBuf;
		stProcessCommand.m_strCSTID.TrimLeft(' ');
		stProcessCommand.m_strCSTID.TrimRight(' ');
		nIndex += 16;

		//	Map_Stif
		memcpy(&stProcessCommand.m_nMap_Stif, &pData[nIndex], 4);
		nIndex += 4;

		//	Start_Stif
		memcpy(&stProcessCommand.m_nStart_Stif, &pData[nIndex], 4);
		nIndex += 4;
		break;
	case 2:
		nIndex +=28;
		//	CommandID
		memcpy(&stProcessCommand.m_nCommandID, &pData[nIndex], 2);
		nIndex += 2;

		// ByWho
		memcpy(&stProcessCommand.m_nByWho, &pData[nIndex], 2);
		nIndex += 2;

		//	Cassette ID
		memset(szBuf, 0x00, sizeof(szBuf));
		memcpy(szBuf, &pData[nIndex], 16);
		CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
		stProcessCommand.m_strCSTID = szBuf;
		stProcessCommand.m_strCSTID.TrimLeft(' ');
		stProcessCommand.m_strCSTID.TrimRight(' ');
		nIndex += 16;

		//	Map_Stif
		memcpy(&stProcessCommand.m_nMap_Stif, &pData[nIndex], 4);
		nIndex += 4;

		//	Start_Stif
		memcpy(&stProcessCommand.m_nStart_Stif, &pData[nIndex], 4);
		nIndex += 4;
		break;
	case 3:
		nIndex +=56;
		//	CommandID
		memcpy(&stProcessCommand.m_nCommandID, &pData[nIndex], 2);
		nIndex += 2;

		// ByWho
		memcpy(&stProcessCommand.m_nByWho, &pData[nIndex], 2);
		nIndex += 2;

		//	Cassette ID
		memset(szBuf, 0x00, sizeof(szBuf));
		memcpy(szBuf, &pData[nIndex], 16);
		CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
		stProcessCommand.m_strCSTID = szBuf;
		stProcessCommand.m_strCSTID.TrimLeft(' ');
		stProcessCommand.m_strCSTID.TrimRight(' ');
		nIndex += 16;

		//	Map_Stif
		memcpy(&stProcessCommand.m_nMap_Stif, &pData[nIndex], 4);
		nIndex += 4;

		//	Start_Stif
		memcpy(&stProcessCommand.m_nStart_Stif, &pData[nIndex], 4);
		nIndex += 4;
		break;
	case 4:
		nIndex +=84;
		//	CommandID
		memcpy(&stProcessCommand.m_nCommandID, &pData[nIndex], 2);
		nIndex += 2;

		// ByWho
		memcpy(&stProcessCommand.m_nByWho, &pData[nIndex], 2);
		nIndex += 2;

		//	Cassette ID
		memset(szBuf, 0x00, sizeof(szBuf));
		memcpy(szBuf, &pData[nIndex], 16);
		CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
		stProcessCommand.m_strCSTID = szBuf;
		stProcessCommand.m_strCSTID.TrimLeft(' ');
		stProcessCommand.m_strCSTID.TrimRight(' ');
		nIndex += 16;

		//	Map_Stif
		memcpy(&stProcessCommand.m_nMap_Stif, &pData[nIndex], 4);
		nIndex += 4;

		//	Start_Stif
		memcpy(&stProcessCommand.m_nStart_Stif, &pData[nIndex], 4);
		nIndex += 4;
		break;
	}


}

void CEQPLCDlg::DuplicatedDataReq(int nPLCNo,int nPortNo, CString &strH_PanelID, CString &strUniqueID, CString &strResult1, CString &strResult2, CString &strResult3)
{
	CString strTag;
	int nIndex = 0;
	char szBuf[20];
	unsigned char szBuf1[10];
	char *pData = NULL;

	INT32 nData[24];
	memset(nData, 0x00, sizeof(INT32) * 24);

	strTag = "U_01_DuplicatedData";
	m_objEIP.receiveValues((char *)m_strEQIP.operator LPCTSTR(), (char *)strTag.operator LPCTSTR(), 0, nData, 24);

	pData = (char*)nData;

	switch(nPortNo)
	{
	case 1:
		//	H_PANELID
		memset(szBuf, 0x00, sizeof(szBuf));
		memcpy(szBuf, &pData[nIndex], 12);
		CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
		strH_PanelID = szBuf;
		strH_PanelID.TrimLeft(' ');
		strH_PanelID.TrimRight(' ');
		nIndex += 12;

		//	UNIQUEID
		memset(szBuf1, 0x00, sizeof(szBuf1));
		memcpy(szBuf1, &pData[nIndex], 4);
		strUniqueID.Format(_T("%d %d %d %d"),szBuf1[0], szBuf1[1], szBuf1[2], szBuf1[3]);
		nIndex += 4;

		//	Result1
		memset(szBuf1, 0x00, sizeof(szBuf1));
		memcpy(szBuf1, &pData[nIndex], 2);
		strResult1.Format(_T("%d"),szBuf1[0]);
		nIndex += 2;

		//	Result2
		memset(szBuf1, 0x00, sizeof(szBuf1));
		memcpy(szBuf1, &pData[nIndex], 2);
		strResult2.Format(_T("%d"),szBuf1[0]);
		nIndex += 2;

		//	Result3
		memset(szBuf1, 0x00, sizeof(szBuf1));
		memcpy(szBuf1, &pData[nIndex], 2);
		strResult3.Format(_T("%d"),szBuf1[0]);
		nIndex += 2;

		// Reserved
		nIndex += 2;

		break;
	case 2:
		nIndex +=24;
		//	H_PANELID
		memset(szBuf, 0x00, sizeof(szBuf));
		memcpy(szBuf, &pData[nIndex], 12);
		CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
		strH_PanelID = szBuf;
		strH_PanelID.TrimLeft(' ');
		strH_PanelID.TrimRight(' ');
		nIndex += 12;

		//	UNIQUEID
		memset(szBuf1, 0x00, sizeof(szBuf1));
		memcpy(szBuf1, &pData[nIndex], 4);
		strUniqueID.Format(_T("%d %d %d %d"),szBuf1[0], szBuf1[1], szBuf1[2], szBuf1[3]);
		nIndex += 4;

		//	Result1
		memset(szBuf1, 0x00, sizeof(szBuf1));
		memcpy(szBuf1, &pData[nIndex], 2);
		strResult1.Format(_T("%d"),szBuf1[0]);
		nIndex += 2;

		//	Result2
		memset(szBuf1, 0x00, sizeof(szBuf1));
		memcpy(szBuf1, &pData[nIndex], 2);
		strResult2.Format(_T("%d"),szBuf1[0]);
		nIndex += 2;

		//	Result3
		memset(szBuf1, 0x00, sizeof(szBuf1));
		memcpy(szBuf1, &pData[nIndex], 2);
		strResult3.Format(_T("%d"),szBuf1[0]);
		nIndex += 2;

		// Reserved
		nIndex += 2;

		break;
	case 3:
		nIndex +=48;
		//	H_PANELID
		memset(szBuf, 0x00, sizeof(szBuf));
		memcpy(szBuf, &pData[nIndex], 12);
		CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
		strH_PanelID = szBuf;
		strH_PanelID.TrimLeft(' ');
		strH_PanelID.TrimRight(' ');
		nIndex += 12;

		//	UNIQUEID
		memset(szBuf1, 0x00, sizeof(szBuf1));
		memcpy(szBuf1, &pData[nIndex], 4);
		strUniqueID.Format(_T("%d %d %d %d"),szBuf1[0], szBuf1[1], szBuf1[2], szBuf1[3]);
		nIndex += 4;

		//	Result1
		memset(szBuf1, 0x00, sizeof(szBuf1));
		memcpy(szBuf1, &pData[nIndex], 2);
		strResult1.Format(_T("%d"),szBuf1[0]);
		nIndex += 2;

		//	Result2
		memset(szBuf1, 0x00, sizeof(szBuf1));
		memcpy(szBuf1, &pData[nIndex], 2);
		strResult2.Format(_T("%d"),szBuf1[0]);
		nIndex += 2;

		//	Result3
		memset(szBuf1, 0x00, sizeof(szBuf1));
		memcpy(szBuf1, &pData[nIndex], 2);
		strResult3.Format(_T("%d"),szBuf1[0]);
		nIndex += 2;

		// Reserved
		nIndex += 2;

		break;
	case 4:
		nIndex +=72;
		//	H_PANELID
		memset(szBuf, 0x00, sizeof(szBuf));
		memcpy(szBuf, &pData[nIndex], 12);
		CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
		strH_PanelID = szBuf;
		strH_PanelID.TrimLeft(' ');
		strH_PanelID.TrimRight(' ');
		nIndex += 12;

		//	UNIQUEID
		memset(szBuf1, 0x00, sizeof(szBuf1));
		memcpy(szBuf1, &pData[nIndex], 4);
		strUniqueID.Format(_T("%d %d %d %d"),szBuf1[0], szBuf1[1], szBuf1[2], szBuf1[3]);
		nIndex += 4;

		//	Result1
		memset(szBuf1, 0x00, sizeof(szBuf1));
		memcpy(szBuf1, &pData[nIndex], 2);
		strResult1.Format(_T("%d"),szBuf1[0]);
		nIndex += 2;

		//	Result2
		memset(szBuf1, 0x00, sizeof(szBuf1));
		memcpy(szBuf1, &pData[nIndex], 2);
		strResult2.Format(_T("%d"),szBuf1[0]);
		nIndex += 2;

		//	Result3
		memset(szBuf1, 0x00, sizeof(szBuf1));
		memcpy(szBuf1, &pData[nIndex], 2);
		strResult3.Format(_T("%d"),szBuf1[0]);
		nIndex += 2;

		// Reserved
		nIndex += 2;

		break;
	}

	
}
void CEQPLCDlg::PCDataReply1(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strTestLog, _T("Signal PCData Event - PortNo=1 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Duplication Event - PortNo=1 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));
	m_ctrlLogList.AddString(m_strLog);*/

	if(FALSE == bSet)
	{
		m_pPLCSignalCommand->EventSignalPCData1(bSet);
	}
}
void CEQPLCDlg::PCDataReply2(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strTestLog, _T("Signal PCData Event - PortNo=1 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Duplication Event - PortNo=1 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));
	m_ctrlLogList.AddString(m_strLog);*/

	if(FALSE == bSet)
	{
		m_pPLCSignalCommand->EventSignalPCData2(bSet);
	}
}
void CEQPLCDlg::PCDataReply3(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strTestLog, _T("Signal PCData Event - PortNo=1 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Duplication Event - PortNo=1 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));
	m_ctrlLogList.AddString(m_strLog);*/

	if(FALSE == bSet)
	{
		m_pPLCSignalCommand->EventSignalPCData3(bSet);
	}
}
void CEQPLCDlg::PCDataReply4(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strTestLog, _T("Signal PCData Event - PortNo=1 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Duplication Event - PortNo=1 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));
	m_ctrlLogList.AddString(m_strLog);*/

	if(FALSE == bSet)
	{
		m_pPLCSignalCommand->EventSignalPCData4(bSet);
	}
}

void CEQPLCDlg::EventSignalPort1Duplication(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Duplication Event - PortNo=1 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Duplication Event - PortNo=1 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));
	m_ctrlLogList.AddString(m_strLog);*/

	m_pPLCSignalCommand->EventSignalPort1Duplication(bSet);
	if(FALSE == bSet)	return;

	int nPortNo = 1;
	CString strH_PanelID ="";
	CString strUniqueID ="";
	CString strResult1 = "";
	CString strResult2 = "";
	CString strResult3 = "";

	DuplicatedDataReq(nPLCNo, nPortNo, strH_PanelID, strUniqueID, strResult1, strResult2, strResult3);

	CMsgPortDuplicationEvent* pMsg = new CMsgPortDuplicationEvent();

	pMsg->m_nPort = nPortNo;
	pMsg->m_strH_PanelID = strH_PanelID;
	pMsg->m_strUniqueID = strUniqueID;
	pMsg->m_strResult1 = strResult1;
	pMsg->m_strResult2 = strResult2;
	pMsg->m_strResult3 = strResult3;


	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, "Unit#01");
	m_LCIFDlg.OnPLCEvent(msg);
}

void CEQPLCDlg::EventSignalPort2Duplication(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Duplication Event - PortNo=2 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Duplication Event - PortNo=2 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));
	m_ctrlLogList.AddString(m_strLog);*/

	m_pPLCSignalCommand->EventSignalPort2Duplication(bSet);
	if(FALSE == bSet)	return;

	int nPortNo = 2;
	CString strH_PanelID ="";
	CString strUniqueID ="";
	CString strResult1 = "";
	CString strResult2 = "";
	CString strResult3 = "";

	DuplicatedDataReq(nPLCNo, nPortNo, strH_PanelID, strUniqueID, strResult1, strResult2, strResult3);

	CMsgPortDuplicationEvent* pMsg = new CMsgPortDuplicationEvent();

	pMsg->m_nPort = nPortNo;
	pMsg->m_strH_PanelID = strH_PanelID;
	pMsg->m_strUniqueID = strUniqueID;
	pMsg->m_strResult1 = strResult1;
	pMsg->m_strResult2 = strResult2;
	pMsg->m_strResult3 = strResult3;

	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, "Unit#02");
	m_LCIFDlg.OnPLCEvent(msg);
}

void CEQPLCDlg::EventSignalPort3Duplication(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Duplication Event - PortNo=3 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Duplication Event - PortNo=3 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));
	m_ctrlLogList.AddString(m_strLog);*/

	m_pPLCSignalCommand->EventSignalPort3Duplication(bSet);
	if(FALSE == bSet)	return;

	int nPortNo = 3;
	CString strH_PanelID ="";
	CString strUniqueID ="";
	CString strResult1 = "";
	CString strResult2 = "";
	CString strResult3 = "";

	DuplicatedDataReq(nPLCNo, nPortNo, strH_PanelID, strUniqueID, strResult1, strResult2, strResult3);

	CMsgPortDuplicationEvent* pMsg = new CMsgPortDuplicationEvent();

	pMsg->m_nPort = nPortNo;
	pMsg->m_strH_PanelID = strH_PanelID;
	pMsg->m_strUniqueID = strUniqueID;
	pMsg->m_strResult1 = strResult1;
	pMsg->m_strResult2 = strResult2;
	pMsg->m_strResult3 = strResult3;

	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, "Unit#03");
	m_LCIFDlg.OnPLCEvent(msg);
}

void CEQPLCDlg::EventSignalPort4Duplication(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Duplication Event - PortNo=4 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Duplication Event - PortNo=4 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));
	m_ctrlLogList.AddString(m_strLog);*/

	CString str = "";

	m_pPLCSignalCommand->EventSignalPort4Duplication(bSet);
	if(FALSE == bSet)	return;

	int nPortNo = 4;
	CString strH_PanelID ="";
	CString strUniqueID ="";
	CString strResult1 = "";
	CString strResult2 = "";
	CString strResult3 = "";

	DuplicatedDataReq(nPLCNo, nPortNo, strH_PanelID, strUniqueID, strResult1, strResult2, strResult3);

	CMsgPortDuplicationEvent* pMsg = new CMsgPortDuplicationEvent();

	pMsg->m_nPort = nPortNo;
	pMsg->m_strH_PanelID = strH_PanelID;
	pMsg->m_strUniqueID = strUniqueID;
	pMsg->m_strResult1 = strResult1;
	pMsg->m_strResult2 = strResult2;
	pMsg->m_strResult3 = strResult3;

	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, "Unit#04");
	m_LCIFDlg.OnPLCEvent(msg);
}

void CEQPLCDlg::EventSignalPort1(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Port Event - PortNo=1 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));
	/*m_strLog.Format(_T("Signal Port Event - PortNo=1 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));
	m_ctrlLogList.AddString(m_strLog);*/

	m_pPLCSignalCommand->EventSignalPort1(bSet);
	//if(FALSE == bSet)	return;

	//m_nPortNo = 1;
	//PostMessage(WM_EVENT_PORT, (WPARAM) nPLCNo, (LPARAM)m_nPortNo);
}



void CEQPLCDlg::EventSignalPort2(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Port Event - PortNo=2 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Port Event - PortNo=2 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));
	m_ctrlLogList.AddString(m_strLog);*/

	m_pPLCSignalCommand->EventSignalPort2(bSet);
	//if(FALSE == bSet)	return;

	//m_nPortNo = 2;
	//PostMessage(WM_EVENT_PORT, (WPARAM) nPLCNo, (LPARAM)m_nPortNo);
}

void CEQPLCDlg::EventSignalPort3(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Port Event - PortNo=3 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Port Event - PortNo=3 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));
	m_ctrlLogList.AddString(m_strLog);*/

	m_pPLCSignalCommand->EventSignalPort3(bSet);
	//if(FALSE == bSet)	return;

	//m_nPortNo = 3;
	//PostMessage(WM_EVENT_PORT, (WPARAM) nPLCNo, (LPARAM)m_nPortNo);

}

void CEQPLCDlg::EventSignalPort4(int nPLCNo, BOOL bSet)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Port Event - PortNo=4 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));

	/*m_strLog.Format(_T("Signal Port Event - PortNo=4 / Signal=%s"), bSet ? _T("TRUE") : _T("FLASE"));
	m_ctrlLogList.AddString(m_strLog);*/

	m_pPLCSignalCommand->EventSignalPort4(bSet);
	//if(FALSE == bSet)	return;

	//m_nPortNo = 4;
	//PostMessage(WM_EVENT_PORT, (WPARAM) nPLCNo, (LPARAM)m_nPortNo);
}

void CEQPLCDlg::EventSignalUnitReport(int nPLCNo, int nUnitNo, BOOL bSet)
{
	TRACE("EventSignalUnitReport - PLCNo=%d / UnitNo=%d / Signal=%s\n", nPLCNo, nUnitNo, bSet ? "TRUE" : "FLASE");
	m_pPLCSignalCommand->EventSignalUnitReport(nUnitNo, bSet);
}

void CEQPLCDlg::EventSignalUnitCtrlCmd(int nPLCNo, int nUnitNo)
{
	TRACE("EventSignalUnitCtrlCmd - PLCNo=%d / UnitNo=%d\n", nPLCNo, nUnitNo);
	m_pPLCSignalCommand->EventSignalUnitCtrlCmd(nUnitNo, FALSE);
}

void CEQPLCDlg::EventCommonState(int nPLCNo, CString &strPMCode, CString &strPauseCode, short nByWho)
{
	//CUtil::WriteLogFile(CABConfig::g_strLog, _T("Equipment State - PLCNo=%d / PMCode=%s / PauseCode=%s / ByWho=%d"), nPLCNo, strPMCode, strPauseCode, nByWho);
	
	/*m_strLog.Format(_T("Equipment State - PLCNo=%d / PMCode=%s / PauseCode=%s / ByWho=%d"), nPLCNo, strPMCode, strPauseCode, nByWho);
	m_ctrlLogList.AddString(m_strLog);*/	
	
	m_stCommonState.strPMCode = strPMCode;
	m_stCommonState.strPauseCode = strPauseCode;
	m_stCommonState.nByWho = nByWho;
}

void CEQPLCDlg::CommonStateReq(int nPLCNo, int nUnitNo)
{
	CString strTag;
	int nIndex = 0;
	char szBuf[8];
	char *pData = NULL;

	INT32 nData[20];
	memset(nData, 0x00, sizeof(INT32) * 20);

	strTag = "U_01_EQCodeState";
	m_objEIP.receiveValues((char *)m_strEQIP.operator LPCTSTR(), (char *)strTag.operator LPCTSTR(), 0, nData, 3);

	pData = (char*)nData;

	//	PM Code
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 4);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stCommonState.strPMCode = szBuf;
	m_stCommonState.strPMCode.TrimLeft(' ');
	m_stCommonState.strPMCode.TrimRight(' ');
	nIndex += 4;

	//	PAUSE Code
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 4);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stCommonState.strPauseCode = szBuf;
	m_stCommonState.strPauseCode.TrimLeft(' ');
	m_stCommonState.strPauseCode.TrimRight(' ');
	nIndex += 4;

	//	ByWho
	memcpy(&m_stCommonState.nByWho, &pData[nIndex], 2);
	nIndex += 2;
}

void CEQPLCDlg::EventState(int nPLCNo, int nUnitNo, int nEQnProcessStatus, short nByWhoEQ, short nByWhoProcess)
{
	CString str="";

	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Unit State - PLCNo=%d / UnitNo=%d / EQ&ProcessStatus=%d / EQByWho=%d / ProcessByWho=%d"),
						nPLCNo, nUnitNo, nEQnProcessStatus, nByWhoEQ, nByWhoProcess);

	CommonStateReq(nPLCNo, nUnitNo);
	
	CMsgUnitStateReport* pMsg = new CMsgUnitStateReport();

	pMsg->strUnitName = m_szUnitName[nUnitNo -1];
	pMsg->strPMCode = m_stCommonState.strPMCode;
	pMsg->strPauseCode = m_stCommonState.strPauseCode;

	char szByWho[32];
	memset(szByWho, 0x00, sizeof(szByWho));
	sprintf(szByWho, "%d", m_stCommonState.nByWho);
	pMsg->strByWho = szByWho;
	memset(szByWho, 0x00, sizeof(szByWho));
	sprintf(szByWho, "%d", nByWhoEQ);
	pMsg->strByWhoEQ = szByWho;
	memset(szByWho, 0x00, sizeof(szByWho));
	sprintf(szByWho, "%d", nByWhoProcess);
	pMsg->strByWhoProcess = szByWho;

		 if(0 != (nEQnProcessStatus & 0x0001))	pMsg->strEQState = "1";
	else if(0 != (nEQnProcessStatus & 0x0002))	pMsg->strEQState = "2";
	else if(0 != (nEQnProcessStatus & 0x0004))	pMsg->strEQState = "3";

		 if(0 != (nEQnProcessStatus & 0x0100))	pMsg->strProcessState = "1";
	else if(0 != (nEQnProcessStatus & 0x0200))	pMsg->strProcessState = "2";
	else if(0 != (nEQnProcessStatus & 0x0400))	pMsg->strProcessState = "3";
	else if(0 != (nEQnProcessStatus & 0x0800))	pMsg->strProcessState = "4";
	else if(0 != (nEQnProcessStatus & 0x1000))	pMsg->strProcessState = "5";
	else if(0 != (nEQnProcessStatus & 0x2000))	pMsg->strProcessState = "6";
	else if(0 != (nEQnProcessStatus & 0x4000))	pMsg->strProcessState = "7";

	m_objInitStateReport.Add(nUnitNo, atoi(pMsg->strEQState), atoi(pMsg->strProcessState));

	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, pMsg->strUnitName);
	m_LCIFDlg.OnPLCEvent(msg);
}

void CEQPLCDlg::EventMasterAlarm(int nPLCNo, int nMasterAlarmNo, int nMasterAlarm, BOOL bAlarm)
{
	CString str="";
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Equpment Master Alarm - MasterAlarmNo : %d / MasterAlarm : %d / Flag = %d"),
						nMasterAlarmNo, nMasterAlarm, (int)bAlarm);

	/*m_strLog.Format(_T("Equpment Master Alarm - MasterAlarmNo : %d / MasterAlarm : %d / Flag = %d"),
		nMasterAlarmNo, nMasterAlarm, (int)bAlarm);
	m_ctrlLogList.AddString(m_strLog);	*/

	if(13 < nMasterAlarmNo)	
		return;
	CMsgAlarmReport* pMsg = new CMsgAlarmReport(bAlarm);

	m_objInitAlarmReport.AddMaster(nMasterAlarmNo+1, nMasterAlarm, bAlarm);

	pMsg->strUnitName = m_szMasterAlarmName;
	char szBuf[4];
	memset(szBuf, 0x00, sizeof(szBuf));
	sprintf(szBuf, "%d", nMasterAlarm + 32 * nMasterAlarmNo);
	pMsg->strAlarmValue = szBuf;

	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, pMsg->strUnitName);
	m_LCIFDlg.OnPLCEvent(msg);
}



void CEQPLCDlg::EventUnitAlarm(int nPLCNo, int nUnitNo, int nUnitAlarm, BOOL bAlarm)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Unit Alarm - UnitNo : %d / UnitAlarm : %d / Flag = %d"),
						nUnitNo, nUnitAlarm, bAlarm);

	//CString str="";

	/*m_strLog.Format(_T("Unit Alarm - UnitNo : %d / UnitAlarm : %d / Flag = %d"),
		nUnitNo, nUnitAlarm, bAlarm);
	m_ctrlLogList.AddString(m_strLog);	*/

	CMsgAlarmReport* pMsg = new CMsgAlarmReport(bAlarm);

	m_objInitAlarmReport.AddUnit(nUnitNo, nUnitAlarm, bAlarm);

	pMsg->strUnitName = m_szUnitName[nUnitNo - 1];
	char szBuf[4];
	memset(szBuf, 0x00, sizeof(szBuf));
	sprintf(szBuf, "%d", nUnitAlarm);
	pMsg->strAlarmValue = szBuf;

	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, pMsg->strUnitName);
	m_LCIFDlg.OnPLCEvent(msg);
}

void CEQPLCDlg::EventPanel(int nPLCNo, int nUnitNo, int nEventID, CString &strHPanelID, CString strBrokenCode)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Unit Event - PLCNo : %d / UnitNo : %d / EventID : %d / HPanelID = %s / BrokenCode = %s"),
						nPLCNo, nUnitNo, nEventID, strHPanelID, strBrokenCode);

	/*m_strLog.Format(_T("Unit Event - PLCNo : %d / UnitNo : %d / EventID : %d / HPanelID = %s / BrokenCode = %d"),
		nPLCNo, nUnitNo, nEventID, strHPanelID, nBrokenCode);
	m_ctrlLogList.AddString(m_strLog);	*/

	char szComp[64];
	memset(szComp, 0x00, sizeof(szComp));
	sprintf(szComp, "U_%02d_TransferGlassDataUnit%d", nPLCNo + 1, nUnitNo);

	PLC::CPLCGlassData* pGlassData;
	if(pGlassData = dynamic_cast<PLC::CPLCGlassData*>(m_vtEQPLC[CABConfig::g_nEQStartCount + nUnitNo - 2]))
	{
		pGlassData->m_stGlassData.m_nGlassExistFlag = 0;
		pGlassData->m_stGlassData.m_nEventID = nEventID;
	}

	int nComp14;
	int nComp17;
	nComp14 = nEventID & 0x04;
	nComp17 = nEventID & 0x20;
	if(0x04 == nComp14 || 0x20 == nComp17)
	{
		int i, nCnt = CABConfig::g_vtTag.size();
		for(i = 0; i < nCnt; i++)
		{
			if(0 == CABConfig::g_vtTag[i]->strName.Compare(szComp))
			{
				if(0 == CABConfig::g_vtTag[i]->nOut)
					return;
				break;
			}
		}
		if(i == nCnt)
			return;
	}

	CMsgGlassControlReport* pMsg = new CMsgGlassControlReport();

	pMsg->strUnitName = m_szUnitName[nUnitNo - 1];
	nComp14 = nEventID & 0x04;
	if(0x04 == nComp14)		pMsg->strEventID = "14";
	nComp17 = nEventID & 0x20;
	if(0x20 == nComp17)		pMsg->strEventID = "17";
	pMsg->strHPanelID = strHPanelID;
	pMsg->strBrokenCode = strBrokenCode;

	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, pMsg->strUnitName);
	m_LCIFDlg.OnPLCEvent(msg);
}

void CEQPLCDlg::EventHSSignal(int nPLCNo, int nUnitNo, int nHSSignalBits, CString &strRefuseCode, short nRefuseBit, BOOL bFlag)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("H/S Signal - PLCNo : %d / UnitNo : %d / HSSignalBits : %d / Flag : %s / Code = %s / Bit = %d"),
						nPLCNo, nUnitNo, nHSSignalBits, bFlag ? _T("TRUE") : _T("FALSE"), strRefuseCode, nRefuseBit);

	/*m_strLog.Format(_T("H/S Signal - PLCNo : %d / UnitNo : %d / HSSignalBits : %d / Flag : %s / Code = %s / Bit = %d"),
		nPLCNo, nUnitNo, nHSSignalBits, bFlag ? _T("TRUE") : _T("FALSE"), strRefuseCode, nRefuseBit);
	m_ctrlLogList.AddString(m_strLog);*/
	
	if(7 == nHSSignalBits)
	{
		if(bFlag)
		{
			if(0 == nRefuseBit)
			{
				CMsgSignalBitsReport* pMsg = new CMsgSignalBitsReport();
				pMsg->strUnitName = m_szUnitName[nUnitNo - 1];
				pMsg->strSignalBit = "413";
				pMsg->strRefuseCode.Format("%s0", strRefuseCode);

				CXMLMsg msg;
				msg.Load(pMsg);
				msg.SetSource(m_strEQName, pMsg->strUnitName);
				m_LCIFDlg.OnPLCEvent(msg);
				return;
			}

			int nComp = 0;
			nComp = nRefuseBit & 0x01;
			if(0x01 == nComp)
			{
				CMsgSignalBitsReport* pMsg = new CMsgSignalBitsReport();
				pMsg->strUnitName = m_szUnitName[nUnitNo - 1];
				pMsg->strSignalBit = "413";
				pMsg->strRefuseCode.Format("%s1", strRefuseCode);

				CXMLMsg msg;
				msg.Load(pMsg);
				msg.SetSource(m_strEQName, pMsg->strUnitName);
				m_LCIFDlg.OnPLCEvent(msg);
			}
			nComp = nRefuseBit & 0x02;
			if(0x02 == nComp)
			{
				CMsgSignalBitsReport* pMsg = new CMsgSignalBitsReport();
				pMsg->strUnitName = m_szUnitName[nUnitNo - 1];
				pMsg->strSignalBit = "413";
				pMsg->strRefuseCode.Format("%s2", strRefuseCode);

				CXMLMsg msg;
				msg.Load(pMsg);
				msg.SetSource(m_strEQName, pMsg->strUnitName);
				m_LCIFDlg.OnPLCEvent(msg);
			}
			nComp = nRefuseBit & 0x04;
			if(0x04 == nComp)
			{
				CMsgSignalBitsReport* pMsg = new CMsgSignalBitsReport();
				pMsg->strUnitName = m_szUnitName[nUnitNo - 1];
				pMsg->strSignalBit = "413";
				pMsg->strRefuseCode.Format("%s3", strRefuseCode);

				CXMLMsg msg;
				msg.Load(pMsg);
				msg.SetSource(m_strEQName, pMsg->strUnitName);
				m_LCIFDlg.OnPLCEvent(msg);
			}
			nComp = nRefuseBit & 0x08;
			if(0x08 == nComp)
			{
				CMsgSignalBitsReport* pMsg = new CMsgSignalBitsReport();
				pMsg->strUnitName = m_szUnitName[nUnitNo - 1];
				pMsg->strSignalBit = "413";
				pMsg->strRefuseCode.Format("%s4", strRefuseCode);

				CXMLMsg msg;
				msg.Load(pMsg);
				msg.SetSource(m_strEQName, pMsg->strUnitName);
				m_LCIFDlg.OnPLCEvent(msg);
			}
			nComp = nRefuseBit & 0x10;
			if(0x10 == nComp)
			{
				CMsgSignalBitsReport* pMsg = new CMsgSignalBitsReport();
				pMsg->strUnitName = m_szUnitName[nUnitNo - 1];
				pMsg->strSignalBit = "413";
				pMsg->strRefuseCode.Format("%s5", strRefuseCode);

				CXMLMsg msg;
				msg.Load(pMsg);
				msg.SetSource(m_strEQName, pMsg->strUnitName);
				m_LCIFDlg.OnPLCEvent(msg);
			}
			nComp = nRefuseBit & 0x20;
			if(0x20 == nComp)
			{
				CMsgSignalBitsReport* pMsg = new CMsgSignalBitsReport();
				pMsg->strUnitName = m_szUnitName[nUnitNo - 1];
				pMsg->strSignalBit = "413";
				pMsg->strRefuseCode.Format("%s6", strRefuseCode);

				CXMLMsg msg;
				msg.Load(pMsg);
				msg.SetSource(m_strEQName, pMsg->strUnitName);
				m_LCIFDlg.OnPLCEvent(msg);
			}
			nComp = nRefuseBit & 0x40;
			if(0x40 == nComp)
			{
				CMsgSignalBitsReport* pMsg = new CMsgSignalBitsReport();
				pMsg->strUnitName = m_szUnitName[nUnitNo - 1];
				pMsg->strSignalBit = "413";
				pMsg->strRefuseCode.Format("%s7", strRefuseCode);

				CXMLMsg msg;
				msg.Load(pMsg);
				msg.SetSource(m_strEQName, pMsg->strUnitName);
				m_LCIFDlg.OnPLCEvent(msg);
			}
			nComp = nRefuseBit & 0x80;
			if(0x80 == nComp)
			{
				CMsgSignalBitsReport* pMsg = new CMsgSignalBitsReport();
				pMsg->strUnitName = m_szUnitName[nUnitNo - 1];
				pMsg->strSignalBit = "413";
				pMsg->strRefuseCode.Format("%s8", strRefuseCode);

				CXMLMsg msg;
				msg.Load(pMsg);
				msg.SetSource(m_strEQName, pMsg->strUnitName);
				m_LCIFDlg.OnPLCEvent(msg);
			}
			nComp = nRefuseBit & 0x100;
			if(0x100 == nComp)
			{
				CMsgSignalBitsReport* pMsg = new CMsgSignalBitsReport();
				pMsg->strUnitName = m_szUnitName[nUnitNo - 1];
				pMsg->strSignalBit = "413";
				pMsg->strRefuseCode.Format("%s9", strRefuseCode);

				CXMLMsg msg;
				msg.Load(pMsg);
				msg.SetSource(m_strEQName, pMsg->strUnitName);
				m_LCIFDlg.OnPLCEvent(msg);
			}
			nComp = nRefuseBit & 0x200;
			if(0x200 == nComp)
			{
				CMsgSignalBitsReport* pMsg = new CMsgSignalBitsReport();
				pMsg->strUnitName = m_szUnitName[nUnitNo - 1];
				pMsg->strSignalBit = "413";
				pMsg->strRefuseCode.Format("%s10", strRefuseCode);

				CXMLMsg msg;
				msg.Load(pMsg);
				msg.SetSource(m_strEQName, pMsg->strUnitName);
				m_LCIFDlg.OnPLCEvent(msg);
			}

			return ;
		}
		else
		{
			CMsgSignalBitsReport* pMsg = new CMsgSignalBitsReport();
			pMsg->strUnitName = m_szUnitName[nUnitNo - 1];
			pMsg->strSignalBit = "413";
			pMsg->strRefuseCode = "OFF";

			CXMLMsg msg;
			msg.Load(pMsg);
			msg.SetSource(m_strEQName, pMsg->strUnitName);
			m_LCIFDlg.OnPLCEvent(msg);
			return;
		}
	}

	CMsgSignalBitsReport* pMsg = new CMsgSignalBitsReport();
	pMsg->strUnitName = m_szUnitName[nUnitNo - 1];

	switch(nHSSignalBits)
	{
	case 2:
		pMsg->strSignalBit = "402";
		if(bFlag)		pMsg->strRefuseCode = "ON";
		else			pMsg->strRefuseCode = "OFF";
		break;
	case 3:
		pMsg->strSignalBit = "403";
		if(bFlag)		pMsg->strRefuseCode = "ON";
		else			pMsg->strRefuseCode = "OFF";
		break;
	case 5:
		pMsg->strSignalBit = "407";
		if(bFlag)		pMsg->strRefuseCode = "ON";
		else			pMsg->strRefuseCode = "OFF";
		break;
	case 6:
		pMsg->strSignalBit = "408";
		if(bFlag)		pMsg->strRefuseCode = "ON";
		else			pMsg->strRefuseCode = "OFF";
		break;
	}

	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, pMsg->strUnitName);
	m_LCIFDlg.OnPLCEvent(msg);
}

void CEQPLCDlg::EventGlassDataReq(int nPLCNo, int nUnitNo)
{
	CString strTag;
	strTag.Format("U_%02d_TransferGlassDataUnit%d", nPLCNo + 1, nUnitNo);

	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Glass Data Request - PLCNo : %d / UnitNo : %d / Tag : %s"),
		nPLCNo, nUnitNo, strTag);

	int nCnt = m_vtEQPLC.size();
	int i, nVarID;
	PLC::IPLC* pPLC = NULL;
	for(i = 0; i < nCnt; i++)
	{
		pPLC = m_vtEQPLC[i];
		if(0 == pPLC->GetTagName().Compare(strTag))
		{
			nVarID = i;
			break;
		}
	}
	if(i >= nCnt)
	{
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("GlassData 누락! VarId : %i, 총사이즈 :nCnt"), i,nCnt);
	}
	m_objEIP.receiveValues((char *)m_strEQIP.operator LPCTSTR(), (char *)strTag.operator LPCTSTR(), nVarID);
	//SendMessage(WM_EVENT_GLASS_REQ, (WPARAM) nPLCNo, (LPARAM) nUnitNo);
}


void CEQPLCDlg::EventWIPQTY(int nPLCNo, PLC::WIPQTY &stWIPQTY)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("WIPQTY - PLCNo : %d" ),nPLCNo);
	/*m_strLog.Format( _T("WIPQTY - PLCNo : %d" ),nPLCNo);
	m_ctrlLogList.AddString(m_strLog);*/

	CMsgWIPQTYEvent* pMsg = new CMsgWIPQTYEvent();

	pMsg->strWIPQTY1PLC1.Format("%d", stWIPQTY.nWIPQTY1PLC1);
	pMsg->strWIPQTY1PLC2.Format("%d", stWIPQTY.nWIPQTY1PLC2);
	pMsg->strWIPQTY2PLC1.Format("%d", stWIPQTY.nWIPQTY2PLC1);
	pMsg->strWIPQTY2PLC2.Format("%d", stWIPQTY.nWIPQTY2PLC2);

	/*m_objInitWIPQTYEvent.strWIPQTY1PLC1.Format("%d", stWIPQTY.nWIPQTY1PLC1);
	m_objInitWIPQTYEvent.strWIPQTY1PLC2.Format("%d", stWIPQTY.nWIPQTY1PLC2);
	m_objInitWIPQTYEvent.strWIPQTY2PLC1.Format("%d", stWIPQTY.nWIPQTY2PLC1);
	m_objInitWIPQTYEvent.strWIPQTY2PLC2.Format("%d", stWIPQTY.nWIPQTY2PLC2);*/

	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, "N/A");
	m_LCIFDlg.OnPLCEvent(msg);
}

void CEQPLCDlg::EventGlassData(int nPLCNo, int nUnitNo, PLC::GLASS_DATA &stGlassData)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Glass Data - PLCNo : %d / UnitNo : %d"),nPLCNo, nUnitNo);
	/*m_strLog.Format(_T("Glass Data - PLCNo : %d / UnitNo : %d"),nPLCNo, nUnitNo);
	m_ctrlLogList.AddString(m_strLog);*/

	CMsgTransferGlassDataReport* pMsg = new CMsgTransferGlassDataReport();

	pMsg->strUnitName = m_szUnitName[nUnitNo - 1];
	pMsg->strExist.Format("%d", stGlassData.m_nGlassExistFlag);
	int nComp;
	nComp = stGlassData.m_nEventID & 0x01;
	if(0x01 == nComp)		pMsg->strEventID = "6";
	nComp = stGlassData.m_nEventID & 0x02;
	if(0x02 == nComp)		pMsg->strEventID = "7";
	nComp = stGlassData.m_nEventID & 0x04;
	if(0x04 == nComp)		pMsg->strEventID = "14";
	nComp = stGlassData.m_nEventID & 0x08;
	if(0x08 == nComp)		pMsg->strEventID = "15";
	nComp = stGlassData.m_nEventID & 0x10;
	if(0x10 == nComp)		pMsg->strEventID = "16";
	nComp = stGlassData.m_nEventID & 0x20;
	if(0x20 == nComp)		pMsg->strEventID = "17";

	pMsg->strHPanelID = stGlassData.m_strHPanelID;
	pMsg->strEPanelID = stGlassData.m_strEPanelID;
	pMsg->strProcessID = stGlassData.m_strProcessID;
	pMsg->strProductID = stGlassData.m_strProductID;
	pMsg->strStepID = stGlassData.m_strStepID;
	pMsg->strBatchID = stGlassData.m_strBatchID;
	pMsg->strProdType = stGlassData.m_strProdType;
	pMsg->strProdKind = stGlassData.m_strProdKind;
	pMsg->strPPID = stGlassData.m_strPPID;
	pMsg->strFlowID = stGlassData.m_strFlowID;
	pMsg->strPanelSize = stGlassData.m_szPanelSize;
	pMsg->strThickness.Format("%d", stGlassData.m_nThickness);
	pMsg->strCompCount.Format("%d", stGlassData.m_nCompCount);
	pMsg->strPanelState.Format("%d", stGlassData.m_nPanelState);
	pMsg->strReadingFlag = stGlassData.m_strReadingFlag;
	pMsg->strInsFlag = stGlassData.m_strInsFlag;
	pMsg->strPanelPosition = stGlassData.m_strPanelPosition;
	pMsg->strJudgement = stGlassData.m_strJudgement;
	pMsg->strCode = stGlassData.m_strJudgementCode;
	pMsg->strFlowHistory = stGlassData.m_szFlowHistory;
	pMsg->strUniqueID = stGlassData.m_szUniqueID;
	pMsg->strCount1 = stGlassData.m_strCount1;
	pMsg->strCount2 = stGlassData.m_strCount2;
	pMsg->strGrade	= stGlassData.m_szGrade;
	pMsg->strMutiUse	= stGlassData.m_strMultiUse;
	pMsg->strGlassDataBitSignal = stGlassData.m_szGlassDataSignal;
	pMsg->strPairHPanelID = stGlassData.m_strPairHPanel;
	pMsg->strPairEPanelID = stGlassData.m_strPairEPanel;
	pMsg->strPairProductID = stGlassData.m_strPairProductID;
	pMsg->strPairGrade = stGlassData.m_szPairGrade;
	pMsg->strFlowGroup = stGlassData.m_szFlowGroup;
	pMsg->strDBRRecipe = stGlassData.m_strDBRRecipe;
	pMsg->strReferData = stGlassData.m_strRefer;
	pMsg->strContactPointState1 = stGlassData.m_strContactPointState1;
	pMsg->strContactPointState2 = stGlassData.m_strContactPointState2;
	pMsg->strFromEQNo.Format("%d", stGlassData.m_nFromEQNo);
	pMsg->strToEQNo.Format("%d", stGlassData.m_nToEQNo);
	pMsg->strSlotID = stGlassData.m_strSlotID;
	//pMsg->strRefuseCode = stGlassData.m_strRefuseCode;
	//pMsg->strHSSignalBit.Format("%d", stGlassData.m_nHSSignalBits);
	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, pMsg->strUnitName);
	m_LCIFDlg.OnPLCEvent(msg);
}

void CEQPLCDlg::EventPort(int nPLCNo, PLC::PortInfoItem strPortInfoItem,int nPortNum)
{
	CString str ="";
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Port Event - PLCNo : %d, PortNo : %d") ,nPLCNo, nPortNum);
	/*m_strLog.Format( _T("Port Event - PLCNo : %d, PortNo : %d") ,nPLCNo, nPortNum);
	m_ctrlLogList.AddString(m_strLog);*/
	//m_nPortNo = nPortNum;

	//if(m_bInitPort ==TRUE)
	//{
	//	m_bInitPort = FALSE;
	//	for(int i=0; i<4; i++)
	//	{
	//		CMsgPortEvent* pMsg = new CMsgPortEvent();

	//		pMsg->nPortNum = i+1;
	//		pMsg->nEventID = strPortInfoItem.m_nEventID;
	//		pMsg->strPortID = strPortInfoItem.m_strPortID;
	//		pMsg->nPortState = strPortInfoItem.m_nPortState;
	//		pMsg->nPortType = strPortInfoItem.m_nPortType;
	//		pMsg->strPortMode = strPortInfoItem.m_strPortMode;
	//		pMsg->nSortType = strPortInfoItem.m_nSortType;
	//		pMsg->nCSTDemand = strPortInfoItem.m_nCSTDemand;
	//		pMsg->strCSTID = strPortInfoItem.m_strCSTID;
	//		pMsg->strCSTType = strPortInfoItem.m_strCSTType;
	//		pMsg->strMat_Stif = strPortInfoItem.m_strMat_Stif;
	//		pMsg->strCur_Stif = strPortInfoItem.m_strCur_Stif;
	//		pMsg->nBatch_Order = strPortInfoItem.m_nBatch_Order;
	//		pMsg->nByWho = strPortInfoItem.m_nByWho;
	//		pMsg->nReply = strPortInfoItem.m_nReply;

	//		str.Format(_T("Unit#0%d"),i+1);
	//		CXMLMsg msg;
	//		msg.Load(pMsg);
	//		msg.SetSource(m_strEQName,str);
	//		m_LCIFDlg.OnPLCEvent(msg);
	//	}
	//}
	/*else
	{*/
		CMsgPortEvent* pMsg = new CMsgPortEvent();
		pMsg->nPortNum = nPortNum;
		pMsg->nEventID = strPortInfoItem.m_nEventID;
		pMsg->strPortID = strPortInfoItem.m_strPortID;
		pMsg->nPortState = strPortInfoItem.m_nPortState;
		pMsg->nPortType = strPortInfoItem.m_nPortType;
		pMsg->strPortMode = strPortInfoItem.m_strPortMode;
		pMsg->nSortType = strPortInfoItem.m_nSortType;
		pMsg->nCSTDemand = strPortInfoItem.m_nCSTDemand;
		pMsg->strCSTID = strPortInfoItem.m_strCSTID;
		pMsg->strCSTType = strPortInfoItem.m_strCSTType;
		pMsg->strMat_Stif = strPortInfoItem.m_strMat_Stif;
		pMsg->strCur_Stif = strPortInfoItem.m_strCur_Stif;
		pMsg->nBatch_Order = strPortInfoItem.m_nBatch_Order;
		pMsg->nByWho = strPortInfoItem.m_nByWho;
		pMsg->nReply = strPortInfoItem.m_nReply;

		str.Format(_T("Unit#0%d"),nPortNum);
		CXMLMsg msg;
		msg.Load(pMsg);
		msg.SetSource(m_strEQName,str);
		m_LCIFDlg.OnPLCEvent(msg);
		/*if(pMsg->EventID == 6)
		{
			CString strLog = msg.GetDoc();
			CUtil::WriteLogFile(CABConfig::g_strLog, strLog);
		}*/
	//}
}

void CEQPLCDlg::EventEQRecipeTable(int nPLCNo, short nEventID, short nFlowRecipeNo, short* pFlowGroup)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("EQ Recipe Table - PLCNo : %d / EvnetID : %d / RecipeNo : %d"),
						nPLCNo, nEventID, nFlowRecipeNo);

	/*m_strLog.Format(_T("EQ Recipe Table - PLCNo : %d / EvnetID : %d / RecipeNo : %d"),
		nPLCNo, nEventID, nFlowRecipeNo);
	m_ctrlLogList.AddString(m_strLog);*/

	if(0 == nEventID)
	{
		m_nEventID = nEventID;
		memcpy(m_nEQFlowGroup, pFlowGroup, sizeof(short) * 10);
	}
	else
	{
		m_nEventID = nEventID;
		m_nFlowRecipeNo = nFlowRecipeNo;
	}
}

void CEQPLCDlg::EventEQRecipeBody(int nPLCNo, int nStartIndex, PLC::FLOW_RECIPE_BODY* pstFlowRecipeBody)
{
	CUtil::WriteLogFile(CABConfig::g_strLog, _T("EQ Recipe Body - PLCNo : %d / StartIndex : %d"),
						nPLCNo, nStartIndex);

	/*m_strLog.Format(_T("EQ Recipe Body - PLCNo : %d / StartIndex : %d"),
		nPLCNo, nStartIndex);
	m_ctrlLogList.AddString(m_strLog);*/

	memcpy(&m_nEQFlowRecipeBody[nStartIndex - 1], pstFlowRecipeBody, sizeof(PLC::FLOW_RECIPE_BODY) * 10);
}


void CEQPLCDlg::OnTimer(UINT_PTR nIDEvent)
{
	// TODO: 여기에 메시지 처리기 코드를 추가 및/또는 기본값을 호출합니다.

		// TODO: 여기에 메시지 처리기 코드를 추가 및/또는 기본값을 호출합니다.
	if(0 == nIDEvent)
	{
		if(!m_LCIFDlg.m_bConnect)
			m_bEQOnline = FALSE;

		int nCnt = CABConfig::g_vtTag.size();
		int i = 0;

		for(i = 0; i < nCnt; i++)
		{
			if(0 == CABConfig::g_vtTag[i]->nConnect && FALSE == m_vtEQPLC[i]->IsOnline())
				break;
		}

		if(i < nCnt)
		{
			if(m_nCount < 3)
			{
				m_nCount += 1;
			}
			else
			{
				if(m_nResult == 1)
				{
					m_nCount = 0;
					m_bPLCConnect = FALSE;
					m_nResult = 0;
					ConnectionEvent(m_nResult);
					//m_LCIFDlg.Stop();
				}
			}
		}
		else
		{
			if(m_nResult == 0)
			{
				m_nCount = 3;
				m_bPLCConnect = TRUE;
				//m_LCIFDlg.Start();
				m_nResult = 1;
				ConnectionEvent(m_nResult);
			}
		}
	}
	else if(1 == nIDEvent)  //PLC 1 Alive 체크
	{
		TRACE("PLCAlive Command 1\n");
		m_pPLCSignalCommand->EventSignalPLCAlive();
		EventSignalBitDataSend(0);
	}
	else if(3 == nIDEvent)
	{
		KillTimer(3);
		m_LCIFDlg.ShowWindow(SW_HIDE);
	}
	else if(4 == nIDEvent)
	{
		KillTimer(4);
		m_pPLCSignalCommand->EventSignalProcessPort1Cmd(TRUE);
		EventSignalBitDataSend(0);
	}
	else if(5 == nIDEvent)
	{
		KillTimer(5);
		m_pPLCSignalCommand->EventSignalProcessPort2Cmd(TRUE);
		EventSignalBitDataSend(0);
	}
	else if(6 == nIDEvent)
	{
		KillTimer(6);
		m_pPLCSignalCommand->EventSignalProcessPort3Cmd(TRUE);
		EventSignalBitDataSend(0);
	}
	else if(7 == nIDEvent)
	{
		KillTimer(7);
		m_pPLCSignalCommand->EventSignalProcessPort4Cmd(TRUE);
		EventSignalBitDataSend(0);
	}
	else if(8 == nIDEvent)
	{
		KillTimer(8);
		m_pPLCSignalCommand->EventSignalProcessPort1Cmd(TRUE);
		m_pPLCSignalCommand->EventSignalProcessPort2Cmd(TRUE);
		EventSignalBitDataSend(0);
	}
	else if(9 == nIDEvent)
	{
		KillTimer(9);
		m_pPLCSignalCommand->EventSignalProcessPort3Cmd(TRUE);
		m_pPLCSignalCommand->EventSignalProcessPort4Cmd(TRUE);
		EventSignalBitDataSend(0);
	}
	else if(10 == nIDEvent)
	{
		KillTimer(10);
		m_pPLCSignalCommand->EventSignalProcessPort1Cmd(TRUE);
		m_pPLCSignalCommand->EventSignalProcessPort2Cmd(TRUE);
		m_pPLCSignalCommand->EventSignalProcessPort3Cmd(TRUE);
		m_pPLCSignalCommand->EventSignalProcessPort4Cmd(TRUE);
		EventSignalBitDataSend(0);
	}
	else if(11 == nIDEvent)
	{
		KillTimer(11);
		m_pPLCSignalCommand->EventSignalPanelID1ReqEvt(TRUE);
		//CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event PC = PanelID1 Request TRUE"));
		EventSignalBitDataSend(0);
	}
	else if(12 == nIDEvent)
	{
		KillTimer(12);
		m_pPLCSignalCommand->EventSignalPanelID2ReqEvt(TRUE);
		//CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event PC = PanelID2 Request TRUE"));
		EventSignalBitDataSend(0);
	}
	else if(13 == nIDEvent)
	{
		KillTimer(13);
		m_pPLCSignalCommand->EventSignalPanelID3ReqEvt(TRUE);
		//CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event PC = PanelID3 Request TRUE"));
		EventSignalBitDataSend(0);
	}
	else if(14 == nIDEvent)
	{
		KillTimer(14);
		m_pPLCSignalCommand->EventSignalPanelID4ReqEvt(TRUE);
		//CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event PC = PanelID4 Request TRUE"));
		EventSignalBitDataSend(0);
	}
	else if(30 == nIDEvent)
	{
		KillTimer(30);
		m_pPLCSignalCommand->EventSignalPCData1(TRUE);
		EventSignalBitDataSend(0);
	}
	else if(31 == nIDEvent)
	{
		KillTimer(31);
		m_pPLCSignalCommand->EventSignalPCData2(TRUE);
		EventSignalBitDataSend(0);
	}
	else if(32 == nIDEvent)
	{
		KillTimer(32);
		m_pPLCSignalCommand->EventSignalPCData3(TRUE);
		EventSignalBitDataSend(0);
	}
	else if(33 == nIDEvent)
	{
		KillTimer(33);
		m_pPLCSignalCommand->EventSignalPCData4(TRUE);
		EventSignalBitDataSend(0);
	}
	else if(18 == nIDEvent)
	{
		if(0 == m_nIconNo)
		{
			HICON hIcon = AfxGetApp()->LoadIcon(IDI_MAINEQPLC);
			m_Ndata.uFlags = NIF_ICON;
			m_Ndata.hIcon = hIcon;
			Shell_NotifyIcon(NIM_MODIFY, &m_Ndata);
			if(m_bPLCConnect)
			{
				m_nIconNo = 1;
			}
			else
			{
				m_nIconNo = 2;
			}
		}
		else
			if(1 == m_nIconNo)
			{
				HICON hIcon = AfxGetApp()->LoadIcon(IDI_MAINEQPLC1);
				m_Ndata.uFlags = NIF_ICON;
				m_Ndata.hIcon = hIcon;
				Shell_NotifyIcon(NIM_MODIFY, &m_Ndata);
				m_nIconNo = 0;
			}
			else
				if(2 == m_nIconNo)
				{
					HICON hIcon = AfxGetApp()->LoadIcon(IDI_MAINEQPLC2);
					m_Ndata.uFlags = NIF_ICON;
					m_Ndata.hIcon = hIcon;
					Shell_NotifyIcon(NIM_MODIFY, &m_Ndata);
					m_nIconNo = 0;
				}

	}
	else if(19 == nIDEvent)
	{
		CUtil::DeleteLogFile(CABConfig::g_strLog, CABConfig::g_nLogTime);
		CUtil::DeleteLogFile(CABConfig::g_strBinaryLog, CABConfig::g_nLogTime);
		CUtil::DeleteLogFile(CABConfig::g_strStateLog, CABConfig::g_nLogTime);
		CUtil::DeleteLogFile(CABConfig::g_strXMLlog, CABConfig::g_nLogTime);
	}
	else if(20 == nIDEvent)
	{
		KillTimer(20);
	}
	__super::OnTimer(nIDEvent);
}

///////////////////////////////////////////////////////////////////////////////
//	Init Method
///////////////////////////////////////////////////////////////////////////////
void CEQPLCDlg::LoadInfo()
{
	for(int i = 0; i < 100; i++)
	{
		memset(m_szUnitName[i], 0x00, sizeof(m_szUnitName[i]));
		sprintf(m_szUnitName[i], "Unit#%02d", i + 1);
	}

	memset(m_szMasterAlarmName, 0x00, sizeof(m_szMasterAlarmName));
	strcpy(m_szMasterAlarmName, "MASTER");
}

void CEQPLCDlg::LoadPLCInfo()
{
	PLC::IPLC *pPLC = NULL;
	for(int i = 0; i < CABConfig::g_vtTag.size(); i++)
	{
		if(0 == CABConfig::g_vtTag[i]->strType.Compare("SignalCommand"))		
			pPLC = new PLC::CPLCSignalCommand;  // P_01_SigCommand
		else if(0 == CABConfig::g_vtTag[i]->strType.Compare("SignalEvent"))		
			pPLC = new PLC::CPLCSignalEvent;    // C_01_SigEvent
		else if(0 == CABConfig::g_vtTag[i]->strType.Compare("SigWordCommand1"))	
			pPLC = new PLC::CPLCSigWordCommand;  //P_01_SigCommandData
		else if(0 == CABConfig::g_vtTag[i]->strType.Compare("SigWordCommand3"))	
			pPLC = new PLC::CPLCSigWordCommand3;  //U_01_EQConstant
		else if(0 == CABConfig::g_vtTag[i]->strType.Compare("PanelIDInfo"))	
			pPLC = new PLC::CPLCPanelIDInfo;  //U_01_PanelIDInfo
		else if(0 == CABConfig::g_vtTag[i]->strType.Compare("CSTInfo1Data"))	
			pPLC = new PLC::CPLCCassetteInfoCommand;  //P_01_CSTInfo1Data
		else if(0 == CABConfig::g_vtTag[i]->strType.Compare("CSTInfo2Data"))
			pPLC = new PLC::CPLCCassetteInfoCommand;  //P_01_CSTInfo2Data
		else if(0 == CABConfig::g_vtTag[i]->strType.Compare("CSTInfo3Data"))
			pPLC = new PLC::CPLCCassetteInfoCommand;  //P_01_CSTInfo3Data
		else if(0 == CABConfig::g_vtTag[i]->strType.Compare("CSTInfo4Data"))
			pPLC = new PLC::CPLCCassetteInfoCommand;  //P_01_CSTInfo4Data
		else if(0 == CABConfig::g_vtTag[i]->strType.Compare("GlassData"))		
			pPLC = new PLC::CPLCGlassData;   //TransferGlassDataUnit
		else if(0 == CABConfig::g_vtTag[i]->strType.Compare("State"))
			pPLC = new PLC::CPLCState; // C_01_EQMSState
		else if(0 == CABConfig::g_vtTag[i]->strType.Compare("StateUnitGroup"))	
			pPLC = new PLC::CPLCStateUnitGroup; //C_01_EQStateUnitto10
		/*else if(0 == CABConfig::g_vtTag[i]->strType.Compare("EQRecipeTable"))	
			pPLC = new PLC::CPLCEQRecipeTable;
		else if(0 == CABConfig::g_vtTag[i]->strType.Compare("EQRecipeBody"))	
			pPLC = new PLC::CPLCEQRecipeBody;*/
		else if(0 == CABConfig::g_vtTag[i]->strType.Compare("PortDataUnit"))
			pPLC = new PLC::CPLCEventObjectUnit;
		else if(0 == CABConfig::g_vtTag[i]->strType.Compare("InitPortDataUnit"))
			pPLC = new PLC::CPLCEventObjectUnit;
		else if(0 == CABConfig::g_vtTag[i]->strType.Compare("WIPQTY"))
			pPLC = new PLC::CPLCWIPQTYEvent;
		// ProcessCommand Test
		else if(0 == CABConfig::g_vtTag[i]->strType.Compare("PCData"))	
			pPLC = new PLC::CPLCSigWordCommand;  //P_01_PCData

		if(1 == CABConfig::g_vtTag[i]->nSave)
			m_pPLCSignalCommand= (PLC::CPLCSignalCommand *)pPLC;
		else if(2 == CABConfig::g_vtTag[i]->nSave)	
			m_pPLCSigWordCommand= (PLC::CPLCSigWordCommand *)pPLC;
		else if(3 == CABConfig::g_vtTag[i]->nSave)	
			m_pCassetteInfoCommand1 = (PLC::CPLCCassetteInfoCommand *)pPLC;
		else if(4 == CABConfig::g_vtTag[i]->nSave)	
			m_pCassetteInfoCommand2= (PLC::CPLCCassetteInfoCommand *)pPLC;
		else if(5 == CABConfig::g_vtTag[i]->nSave)	
			m_pCassetteInfoCommand3= (PLC::CPLCCassetteInfoCommand *)pPLC;
		else if(6 == CABConfig::g_vtTag[i]->nSave)	
			m_pCassetteInfoCommand4= (PLC::CPLCCassetteInfoCommand *)pPLC;
		else if(7 == CABConfig::g_vtTag[i]->nSave)	
			m_pPLCSigWordCommand3 = (PLC::CPLCSigWordCommand3 *)pPLC;
		else if(8 == CABConfig::g_vtTag[i]->nSave)	
			m_pPLCPanelIDInfo = (PLC::CPLCPanelIDInfo *)pPLC;
		// ProcessCommand Test
		else if(9 == CABConfig::g_vtTag[i]->nSave)	
			m_pPLCSigWordCommandTest= (PLC::CPLCSigWordCommand *)pPLC;

		pPLC->SetTagName(CABConfig::g_vtTag[i]->strName);
		m_vtEQPLC.push_back(pPLC);
		pPLC = NULL;
	}
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////TRAY ICON 관련 함수

void CEQPLCDlg::CreateTrayIcon(const char* szToolTip)
{
	HICON hIcon;

	m_Ndata.cbSize = sizeof(NOTIFYICONDATA);
	m_Ndata.hWnd = m_hWnd;
	m_Ndata.uID = IDI_MAINEQPLC;
	m_Ndata.uFlags = NIF_ICON | NIF_MESSAGE | NIF_TIP;
	m_Ndata.uCallbackMessage = WM_EVENT_TRAY_ICON;

	hIcon = (HICON)LoadIcon(AfxGetInstanceHandle(), MAKEINTRESOURCE(IDI_MAINEQPLC));
	m_Ndata.hIcon = hIcon;

	strcpy(m_Ndata.szTip, szToolTip);
	Shell_NotifyIcon(NIM_ADD, &m_Ndata);
}

LRESULT CEQPLCDlg::OnTrayIcon(WPARAM wParam, LPARAM lParam)
{
	HMENU hMenu, hPopupMenu;
	POINT pt;

	switch(lParam)
	{
	case WM_RBUTTONUP:
		hMenu = LoadMenu( ::GetModuleHandle(NULL), MAKEINTRESOURCE(IDR_POPUP) );
		hPopupMenu = GetSubMenu( hMenu, 0 );
		GetCursorPos( &pt );
		::SetForegroundWindow( m_hWnd );
		TrackPopupMenu( hPopupMenu, TPM_LEFTALIGN | TPM_LEFTBUTTON , pt.x, pt.y, 0, m_hWnd, NULL);
		::SetForegroundWindow( m_hWnd );
		DestroyMenu( hPopupMenu );
		DestroyMenu( hMenu );
		break;
	case WM_LBUTTONDBLCLK:
		m_bvisible = TRUE;
		this->ShowWindow(SW_SHOW);
		break;
	}
	return 0;
}

void CEQPLCDlg::OnBinaryLogOn()
{
	if(IDYES == MessageBox("Do you want to record ABPLC Binary Log data?","Record" ,MB_YESNO|MB_ICONQUESTION))
	{
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("Binary Log was excuted by some body!!"));
		CABConfig::g_nBinary = 1;
	}
	else
	{
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("Binary Log was canceled by some body!!"));
		CABConfig::g_nBinary = 0;
	}
}

void CEQPLCDlg::OnXMLLogOn()
{
	if(IDYES == MessageBox("Do you want to record LC&PLC XML Log data?","Record" ,MB_YESNO|MB_ICONQUESTION))
	{
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("XML Log was excuted by some body!!"));
		CABConfig::g_nXML = 1;
	}
	else
	{
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("XML Log was canceled by some body!!"));
		CABConfig::g_nXML = 0;
	}
}

void CEQPLCDlg::OnCloseProgram()
{
	if(IDYES == MessageBox("Do you Really want to close this Program?","WARNING" ,MB_YESNO|MB_ICONWARNING))
	{
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("This Program was closed by some body!!"));
		m_LCIFDlg.Stop();
		Stop_Thread();
		NOTIFYICONDATA data;
		data.cbSize = sizeof(NOTIFYICONDATA);
		data.hWnd = m_hWnd;
		data.uID = IDI_MAINEQPLC;
		KillTimer(8);
		Shell_NotifyIcon(NIM_DELETE, &data);
		CDialog::OnCancel();
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////

LRESULT CEQPLCDlg::OnLCConnect(WPARAM wParam, LPARAM lParam)
{
	int nEvent = (int) wParam;
	if(1 == nEvent)
	{
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("EQPLC%d State Init Message Send"), 1);
		Message::CMsgInitializeUnitStateReport *pInitStateReport1 = new Message::CMsgInitializeUnitStateReport;
		memcpy(pInitStateReport1, &m_objInitStateReport, sizeof(Message::CMsgInitializeUnitStateReport));

		CXMLMsg msg;
		msg.Load(pInitStateReport1);
		msg.SetSource(m_strEQName, _T("N/A"));
		m_LCIFDlg.OnPLCEvent(msg);

		
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("EQPLC%d Alarm Init Message Send"), 1);
		Message::CMsgInitializeAlarmReport *pInitAlarmReport1 = new Message::CMsgInitializeAlarmReport;
		memcpy(pInitAlarmReport1, &m_objInitAlarmReport, sizeof(Message::CMsgInitializeAlarmReport));

		msg.Load(pInitAlarmReport1);
		msg.SetSource(m_strEQName, _T("N/A"));
		m_LCIFDlg.OnPLCEvent(msg);

		
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("EQPLC%d,%d Unit Glass Data Init Message Send"), 1, 2);
		int nCnt = m_vtEQPLC.size();
		PLC::CPLCGlassData* pGlassData;
		int nEventID = 0;
		for(int i = 0; i < nCnt; i++)
		{
			if(pGlassData = dynamic_cast<PLC::CPLCGlassData*>(m_vtEQPLC[i]))
			{
				if(1 == pGlassData->m_stGlassData.m_nGlassExistFlag &&
					((pGlassData->m_stGlassData.m_nEventID == 0x02) || (pGlassData->m_stGlassData.m_nEventID == 0x04)))
				{
					nEventID = pGlassData->m_stGlassData.m_nEventID;
					pGlassData->m_stGlassData.m_nEventID = 0;
					this->EventGlassData(pGlassData->GetPLCNo(), pGlassData->GetUnitNo(), pGlassData->m_stGlassData);
					pGlassData->m_stGlassData.m_nEventID = nEventID;
				}
			}
		}
	}
	return NULL;
}

///////////////////////////////////////////////////////////////////////////////
//	PLC Event
///////////////////////////////////////////////////////////////////////////////
LRESULT CEQPLCDlg::OnSignalBit(WPARAM wParam, LPARAM lParam)
{
	int nPLCNo = (int) wParam;
	int nVarID = (int) lParam;
	CString strBuf;
	int nGrade[8];
	char szBuf[255];
	char szBuf2[255];
	char szValue[255];
	int nCount=0;
	TRACE("OnSignalBit - PLCNo=%d / VarID=%d\n", nPLCNo, nVarID);
	char szData[32];
	memset(szData, 0x00, sizeof(szData));
	m_pPLCSignalCommand->GetData(szData);
	if(m_objEIP.changeLocalVariable(nVarID, szData, sizeof(szData)))
	{
		//CUtil::WriteLogFile(CABConfig::g_strLog, _T("PC OPCALL MESSAGE - Result : %d"), szData[1]);
		memcpy(&nGrade[0], &szData[0], 32);
		memset(szBuf, 0x00, sizeof(szBuf));
		_itoa(nGrade[0], szBuf, 2); 
		memset(szBuf2, 0x00, sizeof(szBuf2));
		wsprintf(szBuf2, "%032s", szBuf);
		CUtil::ABPLCBinSwap(szBuf2, strlen(szBuf2));
		memset(szValue, 0x00, sizeof(szValue));
		strcpy(szValue, szBuf2);

		memset(szBuf, 0x00, sizeof(szBuf));
		_itoa(nGrade[1], &szBuf[0], 2);
		memset(szBuf2, 0x00, sizeof(szBuf2));
		wsprintf(szBuf2, "%032s", szBuf);
		CUtil::ABPLCBinSwap(szBuf2, strlen(szBuf2));
		strcpy(&szValue[32], szBuf2);


		for(int j=0; j<29; j++)
		{
				if(nCount == 16)
					nCount +=2;
				else
					if(nCount == 22)
						nCount +=1;
					else
						if(nCount == 28)
							nCount += 4;
						else
							if(nCount == 36)
								nCount +=6;

			strBuf.Format(_T("%c"),szValue[nCount]);
			m_ctrlListPC.SetItemText(j,1, strBuf);
			nCount+=1;						
		}
		nCount=0;
		TRACE("OnSignalBit Success- VarID=%d\n", nVarID);
	}
	return TRUE;
}

LRESULT CEQPLCDlg::OnSignalWord1(WPARAM wParam, LPARAM lParam)
{
	int nPLCNo = (int) wParam;
	int nVarID = (int) lParam;
	TRACE("OnSignalWord1 - PLCNo=%d / VarID=%d\n", nPLCNo, nVarID);

	char szData[384];
	memset(szData,0x00,sizeof(szData));
	m_pPLCSigWordCommand->GetData(szData);
	if(m_objEIP.changeLocalVariable(nVarID, szData, sizeof(szData)))
	{
		TRACE("OnSignalWord1 Success- VarID=%d\n", nVarID);
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("OnSignalWord1 Success"));
	}
	else
	{
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("OnSignalWord1 Fault"));
	}
	return TRUE;
}
LRESULT CEQPLCDlg::OnSignalWord3(WPARAM wParam, LPARAM lParam)
{
	int nPLCNo = (int) wParam;
	int nVarID = (int) lParam;
	TRACE("OnSignalWord3 - PLCNo=%d / VarID=%d\n", nPLCNo, nVarID);

	char szData[248];
	memset(szData,0x00,sizeof(szData));
	m_pPLCSigWordCommand3->GetData(szData);
	if(m_objEIP.changeUCMMVariable((char *)m_strEQIP.operator LPCTSTR(), (char*)m_objEIP.GetTagName(nVarID),szData,sizeof(szData)))
	{
		m_pPLCSignalCommand ->EventSignalEQConstantCmd(TRUE);
		EventSignalBitDataSend(nPLCNo);
		TRACE("OnSignalWord3 Success- VarID=%d\n", nVarID);
	}	
	return TRUE;
}
//ProcessCommandTest
LRESULT CEQPLCDlg::OnSignalWord1Test(WPARAM wParam, LPARAM lParam)
{
	int nPLCNo = (int) wParam;
	int nVarID = (int) lParam;
	TRACE("OnSignalWord1 - PLCNo=%d / VarID=%d\n", nPLCNo, nVarID);

	char szData[384];
	memset(szData,0x00,sizeof(szData));
	m_pPLCSigWordCommandTest->GetData(szData);
	if(m_objEIP.changeLocalVariable(nVarID, szData, sizeof(szData)))
	{
		TRACE("OnSignalWord1 Success- VarID=%d\n", nVarID);
		CUtil::WriteLogFile(CABConfig::g_strTestLog, _T("OnSignalWord1 Success"));
	}
	else
	{
		CUtil::WriteLogFile(CABConfig::g_strTestLog, _T("OnSignalWord1 Fault"));
	}
	return TRUE;
}

LRESULT CEQPLCDlg::OnPanelIDInfo(WPARAM wParam, LPARAM lParam)
{
	int nPortNo = (int) wParam;
	int nVarID = (int) lParam;
	char szData[80];
	memset(szData,0x00,sizeof(szData));
	m_pPLCPanelIDInfo->GetData(nPortNo,szData);
	if(m_objEIP.changeUCMMVariable((char *)m_strEQIP.operator LPCTSTR(), (char*)m_objEIP.GetTagName(nVarID),szData,sizeof(szData)))
	{
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("OnSignalPanelIDInfo Success : Port No = %d"), nPortNo);
		//CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID Infomation Send Port No : %d"), nPortNo);
		//CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID Infomation Send Port No : %s"), szData);
		//int *lpData = (int *) szData;
		//CUtil::WriteLogFile(CABConfig::g_strBinaryLog, _T("PanelID Infomation Binary Port No : %d"), nPortNo);
		/*for(int i=0; i <40; i=i+11)
		{
			CUtil::WriteLogFile(CABConfig::g_strBinaryLog, "-%08X %08X %08X %08X %08X %08X %08X %08X %08X %08X %08X",
			lpData[i], lpData[i+1], lpData[i+2], lpData[i+3], lpData[i+4], lpData[i+5], lpData[i+6], lpData[i+7],
			lpData[i+8], lpData[i+9], lpData[i+10]);
		}*/
		switch(nPortNo)
		{
		case 1:
			if(CPLCSignalEvent::m_bPanelSigBit[0] == TRUE)
			{
				SetTimer(11, 200, NULL);				
			}
			else
			{
				CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID1 Reply 없어요!!"));
			}
			break;
		case 2:
			if(CPLCSignalEvent::m_bPanelSigBit[1] == TRUE)
			{
				SetTimer(12, 200, NULL);				
			}
			else
			{
				CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID2 Reply 없어요!!"));
			}
			break;
		case 3:
			if(CPLCSignalEvent::m_bPanelSigBit[2] == TRUE)
			{
				SetTimer(13, 200, NULL);				
			}
			else
			{
				CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID3 Reply 없어요!!"));
			}
			break;
		case 4:
			if(CPLCSignalEvent::m_bPanelSigBit[3] == TRUE)
			{
				SetTimer(14, 200, NULL);				
			}
			else
			{
				CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID4 Reply 없어요!!"));
			}
			break;
		}

	}
	else
	{
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("OnSignalPanelIDInfo Fault : Port No = %d"), nPortNo);
	}
	return TRUE;
}


LRESULT CEQPLCDlg::OnCassetteInfo1(WPARAM wParam, LPARAM lParam)
{
	int nPLCNo = (int) wParam;
	int nVarID = (int) lParam;
	TRACE("OnCassetteInfo1 - PLCNo=%d / VarID=%d\n", nPLCNo, nVarID);

	char szData[272];
	memset(szData,0x00,sizeof(szData));
	m_pCassetteInfoCommand1->GetData(szData);
	if(m_objEIP.changeLocalVariable(nVarID, szData, sizeof(szData)))
	{
		TRACE("OnCassetteInfo1 Success- VarID=%d\n", nVarID);
	}
	return TRUE;
}

LRESULT CEQPLCDlg::OnCassetteInfo2(WPARAM wParam, LPARAM lParam)
{
	int nPLCNo = (int) wParam;
	int nVarID = (int) lParam;
	TRACE("OnCassetteInfo2 - PLCNo=%d / VarID=%d\n", nPLCNo, nVarID);

	char szData[272];
	memset(szData,0x00,sizeof(szData));
	m_pCassetteInfoCommand2->GetData(szData);
	if(m_objEIP.changeLocalVariable(nVarID, szData, sizeof(szData)))
	{
		TRACE("OnCassetteInfo2 Success- VarID=%d\n", nVarID);
	}
	return TRUE;
}

LRESULT CEQPLCDlg::OnCassetteInfo3(WPARAM wParam, LPARAM lParam)
{
	int nPLCNo = (int) wParam;
	int nVarID = (int) lParam;
	TRACE("OnCassetteInfo2 - PLCNo=%d / VarID=%d\n", nPLCNo, nVarID);

	char szData[272];
	memset(szData,0x00,sizeof(szData));
	m_pCassetteInfoCommand3->GetData(szData);
	if(m_objEIP.changeLocalVariable(nVarID, szData, sizeof(szData)))
	{
		TRACE("OnCassetteInfo3 Success- VarID=%d\n", nVarID);
	}
	return TRUE;
}

LRESULT CEQPLCDlg::OnCassetteInfo4(WPARAM wParam, LPARAM lParam)
{
	int nPLCNo = (int) wParam;
	int nVarID = (int) lParam;
	TRACE("OnCassetteInfo2 - PLCNo=%d / VarID=%d\n", nPLCNo, nVarID);

	char szData[272];
	memset(szData,0x00,sizeof(szData));
	m_pCassetteInfoCommand4->GetData(szData);
	if(m_objEIP.changeLocalVariable(nVarID, szData, sizeof(szData)))
	{
		TRACE("OnCassetteInfo4 Success- VarID=%d\n", nVarID);
	}
	return TRUE;
}


bool CEQPLCDlg::OnLCEvent(CXMLMsg& msg)
{
	CString str="";
	//	Command
	if(msg.GetMessageType() == 1)
	{
		int nPLCNo;
		int nUnitNo;
		CString strEquipment, strUnit;
		msg.GetDestination(strEquipment, strUnit);
		if(0 == strEquipment.Compare(m_strEQName))		
			nPLCNo = 0;
		else												
			return false;

		for(nUnitNo = 0; nUnitNo < 100; nUnitNo++)
		{
			if(0 == strcmp(m_szUnitName[nUnitNo],strUnit))
				break;
		}
		if(100 == nUnitNo)
			nUnitNo = -1;

		switch(msg.GetMessageCommand())
		{
		case 1:
			if(CMsgDateTimeCommand* pDateTime = dynamic_cast<CMsgDateTimeCommand*>(msg.GetInfo()))
			{
				CUtil::WriteLogFile(CABConfig::g_strLog, _T("DateTime Command - PLCNo : %d"), nPLCNo);
				
				/*m_strLog.Format(_T("DateTime Command - PLCNo : %d"), nPLCNo);
				m_ctrlLogList.AddString(m_strLog);*/
				
				PLC::CPLCSigWordCommand::DATETIME stDatetime;

				memset(&stDatetime, 0x00, sizeof(stDatetime));
				CString strBuf;
				strBuf = pDateTime->strDateTime.Mid(0, 4);
				stDatetime.nYear = atoi(strBuf.operator LPCTSTR());
				strBuf = pDateTime->strDateTime.Mid(4, 2);
				stDatetime.nMonth = atoi(strBuf.operator LPCTSTR());
				strBuf = pDateTime->strDateTime.Mid(6, 2);
				stDatetime.nDay = atoi(strBuf.operator LPCTSTR());
				strBuf = pDateTime->strDateTime.Mid(8, 2);
				stDatetime.nHour = atoi(strBuf.operator LPCTSTR());
				strBuf = pDateTime->strDateTime.Mid(10, 2);
				stDatetime.nMinute = atoi(strBuf.operator LPCTSTR());
				strBuf = pDateTime->strDateTime.Mid(12, 2);
				stDatetime.nSecond = atoi(strBuf.operator LPCTSTR());

				m_pPLCSigWordCommand->SetDateTime1(stDatetime);
				m_pPLCSignalCommand->EventSignalDatetimeSet(TRUE);
				EventSigWordData1Send(nPLCNo);
				EventSignalBitDataSend(nPLCNo);
			}
			break;
		case 2:
			if(CMsgEquipmentCommand* pEQCmd = dynamic_cast<CMsgEquipmentCommand*>(msg.GetInfo()))
			{
				CUtil::WriteLogFile(CABConfig::g_strLog, _T("Equipment Command - PLCNo : %d"), nPLCNo);

				/*m_strLog.Format(_T("Equipment Command - PLCNo : %d"), nPLCNo);
				m_ctrlLogList.AddString(m_strLog);*/
				
				PLC::CPLCSigWordCommand::EQ_CMD stEQCmd;
				memset(&stEQCmd, 0x00, sizeof(stEQCmd));
				stEQCmd.nCommandID = pEQCmd->nCommandID;
				stEQCmd.nByWho = pEQCmd->nByWho;
				strcpy(stEQCmd.szCode, pEQCmd->strCode.operator LPCTSTR());
				stEQCmd.nIDnNo = pEQCmd->nNum;
				strcpy(stEQCmd.szTerminalText, pEQCmd->strTerminal.operator LPCTSTR());
				strcpy(stEQCmd.szOPCallText, pEQCmd->strOPCall.operator LPCTSTR());

				m_pPLCSigWordCommand->SetEQCmd(stEQCmd);
				m_pPLCSignalCommand->EventSignalEquipmentCmd(TRUE);
				EventSigWordData1Send(nPLCNo);
				EventSignalBitDataSend(nPLCNo);
			}
			break;
		case 3:
			if(CMsgFlowRecipeControlCommand* pFlowRecipeCmd = dynamic_cast<CMsgFlowRecipeControlCommand*>(msg.GetInfo()))
			{
				CUtil::WriteLogFile(CABConfig::g_strLog, _T("Flow Recipe Control Command - PLCNo : %d"), nPLCNo);
				PLC::CPLCSigWordCommand::FLOW_CMD stFlowRecipeCmd;
				memset(&stFlowRecipeCmd, 0x00, sizeof(stFlowRecipeCmd));
				stFlowRecipeCmd.nCommandID = pFlowRecipeCmd->nCommandID;
				stFlowRecipeCmd.nFlowNo = pFlowRecipeCmd->nFlowNo;
				strcpy(stFlowRecipeCmd.stFlowBody.szFlowID, pFlowRecipeCmd->strFlowID.operator LPCTSTR());
				stFlowRecipeCmd.stFlowBody.nRevision = pFlowRecipeCmd->nRevision;
				CString strBuf;
				strBuf = pFlowRecipeCmd->strTime.Mid(0, 4);
				stFlowRecipeCmd.stFlowBody.nYear = atoi(strBuf.operator LPCTSTR());
				strBuf = pFlowRecipeCmd->strTime.Mid(4, 2);
				stFlowRecipeCmd.stFlowBody.nMonth = atoi(strBuf.operator LPCTSTR());
				strBuf = pFlowRecipeCmd->strTime.Mid(6, 2);
				stFlowRecipeCmd.stFlowBody.nDay = atoi(strBuf.operator LPCTSTR());
				strBuf = pFlowRecipeCmd->strTime.Mid(8, 2);
				stFlowRecipeCmd.stFlowBody.nHour = atoi(strBuf.operator LPCTSTR());
				strBuf = pFlowRecipeCmd->strTime.Mid(10, 2);
				stFlowRecipeCmd.stFlowBody.nMinute = atoi(strBuf.operator LPCTSTR());
				strBuf = pFlowRecipeCmd->strTime.Mid(12, 2);
				stFlowRecipeCmd.stFlowBody.nSecond = atoi(strBuf.operator LPCTSTR());
				memcpy(stFlowRecipeCmd.stFlowBody.nFlowBody, pFlowRecipeCmd->nBody, sizeof(short) * 10);

				m_pPLCSigWordCommand->SetFlowCmd(stFlowRecipeCmd);
				m_pPLCSignalCommand->EventSignalFlowCtrlCmd(TRUE);
				EventSigWordData1Send(nPLCNo);
				EventSignalBitDataSend(nPLCNo);
			}
			break;
		case 4:
			if(CMsgFlowGroupControlCommand* pFlowGroupCmd = dynamic_cast<CMsgFlowGroupControlCommand*>(msg.GetInfo()))
			{
				CUtil::WriteLogFile(CABConfig::g_strLog, _T("Flow Group Control Command - PLCNo : %d"), nPLCNo);
				PLC::CPLCSigWordCommand::FLOW_CMD stFlowRecipeCmd;
				memset(&stFlowRecipeCmd, 0x00, sizeof(stFlowRecipeCmd));
				stFlowRecipeCmd.nCommandID = pFlowGroupCmd->nCommandID;
				memcpy(stFlowRecipeCmd.nFlowGroup, pFlowGroupCmd->nBody, sizeof(short) * 10);

				m_pPLCSigWordCommand->SetFlowCmd(stFlowRecipeCmd);
				m_pPLCSignalCommand->EventSignalFlowCtrlCmd(TRUE);
				EventSigWordData1Send(nPLCNo);
				EventSignalBitDataSend(nPLCNo);
			}
			break;
		case 10:
			if(CMsgEQConstantCommand* pEQConstantCommand = dynamic_cast<CMsgEQConstantCommand*>(msg.GetInfo()))
			{
				CUtil::WriteLogFile(CABConfig::g_strLog, _T("EQ Constant Command - PLCNo : %d"), nPLCNo);
				/*m_strLog.Format(_T("EQ Constant Command - PLCNo : %d"), nPLCNo);
				m_ctrlLogList.AddString(m_strLog);*/

				PLC::CPLCSigWordCommand3::ECID_INFO stECIDCmd[15];
				memset(stECIDCmd, 0x00, sizeof(PLC::CPLCSigWordCommand3::ECID_INFO) * 15);
				memcpy(stECIDCmd, pEQConstantCommand->stECIDInfo, sizeof(PLC::CPLCSigWordCommand3::ECID_INFO) * 15);

				m_pPLCSigWordCommand3 ->SetECIDCmd(pEQConstantCommand->nCommandID, stECIDCmd);
				EventSigWordData3Send(nPLCNo);
			}
			break;
		case 11:
			if(CMsgMessageCommand* pMessageCommand = dynamic_cast<CMsgMessageCommand*>(msg.GetInfo()))
			{
				CUtil::WriteLogFile(CABConfig::g_strLog, _T("Message Command - PLCNo : %d======================"), nPLCNo);

				DataMessageChangeEvent(nPLCNo, pMessageCommand->nNum,pMessageCommand->strTerminal,pMessageCommand->strOPCall);
				
				/*PLC::CPLCSigWordCommand::EQ_CMD stEQCmd;
				memset(&stEQCmd, 0x00, sizeof(stEQCmd));
				stEQCmd.nIDnNo = pMessageCommand->nNum;
				strcpy(stEQCmd.szTerminalText, pMessageCommand->strTerminal.operator LPCTSTR());
				strcpy(stEQCmd.szOPCallText, pMessageCommand->strOPCall.operator LPCTSTR());

				m_pPLCSigWordCommand->SetEQCmd(stEQCmd);
				if(0 < pMessageCommand->strTerminal.GetLength())
				{
					CUtil::WriteLogFile(CABConfig::g_strLog, _T("PC Teminal Message Signal : TRUE"));
					m_pPLCSignalCommand->EventSignalTerminalMsgCmd(TRUE);
				}
				if(0 < pMessageCommand->strOPCall.GetLength())
				{
					CUtil::WriteLogFile(CABConfig::g_strLog, _T("PC OPCALL Message Signal : TRUE"));
					m_pPLCSignalCommand->EventSignalOPCallCmd(TRUE);
				}
				EventSigWordData1Send(nPLCNo);
				EventSignalBitDataSend(nPLCNo);*/
				/*if(0 < pMessageCommand->strTerminal.GetLength())
				{
					CUtil::WriteLogFile(CABConfig::g_strLog, _T("PC Teminal Message Signal : FALSE"));
					m_pPLCSignalCommand->EventSignalTerminalMsgCmd(FALSE);
				}
				if(0 < pMessageCommand->strOPCall.GetLength())
				{
					CUtil::WriteLogFile(CABConfig::g_strLog, _T("PC OPCALL Message Signal : FALSE"));
					m_pPLCSignalCommand->EventSignalOPCallCmd(FALSE);
				}
				SetTimer(20,1000,NULL);
				EventSignalBitDataSend(nPLCNo);*/
			}
			break;
		case 13:
			if(CMSgOnlineModeCommand* pOnlineModeCmd = dynamic_cast<CMSgOnlineModeCommand*>(msg.GetInfo()))
			{
				CUtil::WriteLogFile(CABConfig::g_strLog, _T("OnlineMode Command - PLCNo : %d"), nPLCNo);

				/*m_strLog.Format(_T("OnlineMode Command - PLCNo : %d"), nPLCNo);
				m_ctrlLogList.AddString(m_strLog);*/

				switch(pOnlineModeCmd->nID)
				{
				case 0:
					m_pPLCSignalCommand->EventOnlineModeCmd(FALSE);
					break;
				case 1:
					m_pPLCSignalCommand->EventOnlineModeCmd(TRUE);
					break;
				}
				EventSignalBitDataSend(nPLCNo);
			}
			break;
		case 14:
			if(CMsgProcessCommand* pProcessCmd = dynamic_cast<CMsgProcessCommand*>(msg.GetInfo()))
			{
				CUtil::WriteLogFile(CABConfig::g_strLog, _T("Process Command - PLCNo : %d, PortNo : %d"), nPLCNo, pProcessCmd->nPortNo );

				/*m_strLog.Format(_T("Process Command - PLCNo : %d, PortNo : %d"), nPLCNo, pProcessCmd->nPortNo );
				m_ctrlLogList.AddString(m_strLog);*/

				PLC::CPLCSigWordCommand::ProcessCommand stProcessCmd;
				memset(&stProcessCmd, 0x00, sizeof(stProcessCmd));
     			stProcessCmd.nPortNo = pProcessCmd->nPortNo;
				stProcessCmd.nCommandID = pProcessCmd->nCommandID;
				strcpy(stProcessCmd.szCassetteID, pProcessCmd->strCassetteID.operator LPCTSTR());
				stProcessCmd.nMapStif = pProcessCmd->nMapStif;
				stProcessCmd.nStartStif = pProcessCmd->nStartStif;
				stProcessCmd.nByWho = pProcessCmd->nByWho;

				m_pPLCSigWordCommand->SetProcessCmd(stProcessCmd);
				EventSigWordData1Send(nPLCNo);
				switch(stProcessCmd.nPortNo)
				{
				case 1:
					SetTimer(4, 200, NULL);
					break;
				case 2:
					SetTimer(5, 200, NULL);
					break;
				case 3:
					SetTimer(6, 200, NULL);
					break;
				case 4:
					SetTimer(7, 200, NULL);
					break;
				case 12:
					SetTimer(8, 200, NULL);					
					break;
				case 34:
					SetTimer(9, 200, NULL);					
					break;
				case 1234:
					SetTimer(10, 200, NULL);					
					break;
				}				
				//EventSignalBitDataSend(nPLCNo);
			}
			break;
		case 15:
			if(CMsgCassetteInfoCommand* pCassetteInfoCmd = dynamic_cast<CMsgCassetteInfoCommand*>(msg.GetInfo()))
			{
				CUtil::WriteLogFile(CABConfig::g_strLog, _T("CassetteInfo Command - PLCNo : %d, PortNo : %d"), nPLCNo,pCassetteInfoCmd->nPortNo);

				/*m_strLog.Format(_T("CassetteInfo Command - PLCNo : %d PortNo : %d"), nPLCNo,pCassetteInfoCmd->nPortNo);
				m_ctrlLogList.AddString(m_strLog);*/

				PLC::CPLCCassetteInfoCommand::CassetteInfo stCassetteInfoCmd;
				memset(&stCassetteInfoCmd, 0x00, sizeof(stCassetteInfoCmd));
				stCassetteInfoCmd.nPortNo = pCassetteInfoCmd->nPortNo;
				strcpy(stCassetteInfoCmd.szProcessID, pCassetteInfoCmd->strProcessID.operator LPCTSTR());
				strcpy(stCassetteInfoCmd.szProductID, pCassetteInfoCmd->strProductID.operator LPCTSTR());
				strcpy(stCassetteInfoCmd.szStepID, pCassetteInfoCmd->strStepID.operator LPCTSTR());
				strcpy(stCassetteInfoCmd.szBatchID, pCassetteInfoCmd->strBatchID.operator LPCTSTR());
				strcpy(stCassetteInfoCmd.szProd_Type, pCassetteInfoCmd->strProd_Type.operator LPCTSTR());
				strcpy(stCassetteInfoCmd.szProd_Kind, pCassetteInfoCmd->strProd_Kind.operator LPCTSTR());
				strcpy(stCassetteInfoCmd.szPPID, pCassetteInfoCmd->strPPID.operator LPCTSTR());
				strcpy(stCassetteInfoCmd.szFlowID, pCassetteInfoCmd->strFlowID.operator LPCTSTR());
				memcpy(&stCassetteInfoCmd.nPanel_Size,&pCassetteInfoCmd->nPanel_Size , sizeof(stCassetteInfoCmd.nPanel_Size));
				stCassetteInfoCmd.nThickness = pCassetteInfoCmd->nThickness;
				stCassetteInfoCmd.nComp_Count = pCassetteInfoCmd->nComp_Count;
				stCassetteInfoCmd.nPanel_State = pCassetteInfoCmd->nPanel_State;
				strcpy(stCassetteInfoCmd.szReading_Flag, pCassetteInfoCmd->strReading_Flag.operator LPCTSTR());
				strcpy(stCassetteInfoCmd.szIns_Flag, pCassetteInfoCmd->strIns_Flag.operator LPCTSTR());
				strcpy(stCassetteInfoCmd.szPanel_Position, pCassetteInfoCmd->strPanel_Position.operator LPCTSTR());
				strcpy(stCassetteInfoCmd.szJudgement, pCassetteInfoCmd->strJudgement.operator LPCTSTR());
				strcpy(stCassetteInfoCmd.szCode, pCassetteInfoCmd->strCode.operator LPCTSTR());
				memcpy(&stCassetteInfoCmd.nFlow_History, &pCassetteInfoCmd->nFlow_History, sizeof(pCassetteInfoCmd->nFlow_History));
				strcpy(stCassetteInfoCmd.szCount1, pCassetteInfoCmd->strCount1.operator LPCTSTR());
				strcpy(stCassetteInfoCmd.szCount2, pCassetteInfoCmd->strCount2.operator LPCTSTR());
				memcpy(&stCassetteInfoCmd.nGrade, &pCassetteInfoCmd->nGrade, sizeof(pCassetteInfoCmd->nGrade));
				strcpy(stCassetteInfoCmd.szMulti_Use, pCassetteInfoCmd->strMulti_Use.operator LPCTSTR());
				memcpy(&stCassetteInfoCmd.nGlassDataBitSignal, &pCassetteInfoCmd->nGlassDataBitSignal, sizeof(pCassetteInfoCmd->nGlassDataBitSignal));
				strcpy(stCassetteInfoCmd.szPair_H_PanelID, pCassetteInfoCmd->strPair_H_PanelID.operator LPCTSTR());
				strcpy(stCassetteInfoCmd.szPair_E_PanelID, pCassetteInfoCmd->strPair_E_PanelID.operator LPCTSTR());
				strcpy(stCassetteInfoCmd.szPair_ProductID, pCassetteInfoCmd->strPair_ProductID.operator LPCTSTR());
				memcpy(&stCassetteInfoCmd.nPair_Grade, &pCassetteInfoCmd->nPair_Grade, sizeof(pCassetteInfoCmd->nPair_Grade));
				memcpy(&stCassetteInfoCmd.nFlow_Group, &pCassetteInfoCmd->nFlow_Group, sizeof(pCassetteInfoCmd->nFlow_Group));
				strcpy(stCassetteInfoCmd.szDBR_Recipe, pCassetteInfoCmd->strDBR_Recipe.operator LPCTSTR());
				strcpy(stCassetteInfoCmd.szReferData, pCassetteInfoCmd->strReferData.operator LPCTSTR());

				switch(pCassetteInfoCmd->nPortNo)
				{
				case 1:
					m_pCassetteInfoCommand1->SetCassetteInfoCmd(stCassetteInfoCmd);
					EventCassetteInfoSend1(nPLCNo);
					break;
				case 2:
					m_pCassetteInfoCommand2->SetCassetteInfoCmd(stCassetteInfoCmd);
					EventCassetteInfoSend2(nPLCNo);
					break;
				case 3:
					m_pCassetteInfoCommand3->SetCassetteInfoCmd(stCassetteInfoCmd);
					EventCassetteInfoSend3(nPLCNo);
					break;
				case 4:
					m_pCassetteInfoCommand4->SetCassetteInfoCmd(stCassetteInfoCmd);
					EventCassetteInfoSend4(nPLCNo);
					break;
				}
			}
			break;
		case 16:
			if(CMsgPanelIDInfo* pPanelIDInfo = dynamic_cast<CMsgPanelIDInfo*>(msg.GetInfo()))
			{
				CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID Infomation - PLCNo : %d, Port No : %d"), nPLCNo, pPanelIDInfo->nPortNo);

				/*m_strLog.Format(_T("PanelID Infomation - PLCNo : %d, Port No : %d"), nPLCNo, pPanelIDInfo->nPortNo);
				m_ctrlLogList.AddString(m_strLog);*/

				PLC::CPLCPanelIDInfo::PanelIDInfo stProcessCmd;
				memset(&stProcessCmd, 0x00, sizeof(stProcessCmd));


				stProcessCmd.nPort = pPanelIDInfo->nPortNo;
				strcpy(stProcessCmd.szHPanelID, pPanelIDInfo->strHPanelID.operator LPCTSTR());

				for(int i=0; i<4; i++)
				{
					stProcessCmd.nUniqueID[i] = pPanelIDInfo->nUniqueID[i];
				}

				m_pPLCPanelIDInfo->SetPanelIDInfo(stProcessCmd);

				//EventSigWordData1Send(nPLCNo);
				//OnSignalWord1();
				//CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID Infomation Data- After Set, Port No : %d, PanelID : %s"), stProcessCmd.nPort,stProcessCmd.szHPanelID);
				EventSigPanelIDInfo(stProcessCmd.nPort);

				/*switch(stProcessCmd.nPort)
				{
				case 1:
					if(CPLCSignalEvent::m_bPanelSigBit[0] == TRUE)
					{
						m_pPLCSignalCommand->EventSignalPanelID1ReqEvt(TRUE);
						CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event PC = PanelID1 Request TRUE"));
						EventSignalBitDataSend(nPLCNo);
					}
					else
					{
						CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID1 Reply 없어요!!"));
					}
					break;
				case 2:
					if(CPLCSignalEvent::m_bPanelSigBit[1] == TRUE)
					{
						m_pPLCSignalCommand->EventSignalPanelID2ReqEvt(TRUE);
						CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event PC = PanelID2 Request TRUE"));
						EventSignalBitDataSend(nPLCNo);
					}
					else
					{
						CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID2 Reply 없어요!!"));
					}
					break;
				case 3:
					if(CPLCSignalEvent::m_bPanelSigBit[2] == TRUE)
					{
						m_pPLCSignalCommand->EventSignalPanelID3ReqEvt(TRUE);
						CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event PC = PanelID3 Request TRUE"));
						EventSignalBitDataSend(nPLCNo);
					}
					else
					{
						CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID3 Reply 없어요!!"));
					}
					break;
				case 4:
					if(CPLCSignalEvent::m_bPanelSigBit[3] == TRUE)
					{
						m_pPLCSignalCommand->EventSignalPanelID4ReqEvt(TRUE);
						CUtil::WriteLogFile(CABConfig::g_strLog, _T("Signal Event PC = PanelID4 Request TRUE"));
						EventSignalBitDataSend(nPLCNo);
					}
					else
					{
						CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID4 Reply 없어요!!"));
					}
					break;
				}
			}*/
			}
			break;
		case 17:
			if(CMsgLimitWIPQTYCommand* pLimitWIPQTY = dynamic_cast<CMsgLimitWIPQTYCommand*>(msg.GetInfo()))
			{
				CUtil::WriteLogFile(CABConfig::g_strLog, _T("LimitWIPQTY Command - PLCNo : %d"), nPLCNo);

				/*m_strLog.Format(_T("LimitWIPQTY Command - PLCNo : %d"), nPLCNo);
				m_ctrlLogList.AddString(m_strLog);*/

				PLC::CPLCSigWordCommand::LimitWIPQTY stLimitWIPQTY;
				memset(&stLimitWIPQTY, 0x00, sizeof(stLimitWIPQTY));
				stLimitWIPQTY.nLimitWIPQTY1 = pLimitWIPQTY->nLimitWIPQTY1;
				stLimitWIPQTY.nLimitWIPQTY2 = pLimitWIPQTY->nLimitWIPQTY2;
				
				m_pPLCSigWordCommand->SetLimitWIPQTY(stLimitWIPQTY);

				EventSigWordData1Send(nPLCNo);
			}
			break;

			/*if(CMsgPortStartCommand* pPortStart = dynamic_cast<CMsgPortStartCommand*>(msg.GetInfo()))
			{
				CUtil::WriteLogFile(CABConfig::g_strLog, _T("PortStart Command - PLCNo : %d"), nPLCNo);

				m_strLog.Format(_T("PortStart Command - PLCNo : %d"), nPLCNo);
				m_ctrlLogList.AddString(m_strLog);

				switch(pPortStart->nLine)
				{
				case 1:
					if(pPortStart->nBit == 1)
					{
					  m_pPLCSignalCommand->EventSignalPortStart1(TRUE);
					}
					else
						m_pPLCSignalCommand->EventSignalPortStart1(FALSE);
					break;
				case 2:
					if(pPortStart->nBit == 1)
					{
						m_pPLCSignalCommand->EventSignalPortStart2(TRUE);
					}
					else
						m_pPLCSignalCommand->EventSignalPortStart2(FALSE);
					break;
				}
				EventSignalBitDataSend(nPLCNo);
			}*/
		case 21: // ProcessCommand Test
			if(CMsgPCDataCommand* pProcessCmd = dynamic_cast<CMsgPCDataCommand*>(msg.GetInfo()))
			{
				CUtil::WriteLogFile(CABConfig::g_strTestLog, _T("PCData : PortNo= %d , CommandID = %d, ByWho = %d, CSTID = %s, Map_Stif = %d, Start_Stif = %d"),
					pProcessCmd->nPortNo, pProcessCmd->nCommandID,pProcessCmd->nByWho,pProcessCmd->strCassetteID, pProcessCmd->nMapStif, pProcessCmd->nStartStif);

				PLC::CPLCSigWordCommand::ProcessCommand stProcessCmd;
				memset(&stProcessCmd, 0x00, sizeof(stProcessCmd));
				stProcessCmd.nPortNo = pProcessCmd->nPortNo;
				stProcessCmd.nCommandID = pProcessCmd->nCommandID;
				strcpy(stProcessCmd.szCassetteID, pProcessCmd->strCassetteID.operator LPCTSTR());
				stProcessCmd.nMapStif = pProcessCmd->nMapStif;
				stProcessCmd.nStartStif = pProcessCmd->nStartStif;
				stProcessCmd.nByWho = pProcessCmd->nByWho;

				m_pPLCSigWordCommandTest->SetProcessCmd(stProcessCmd);
				EventSigWordData1SendTest(nPLCNo);
				switch(stProcessCmd.nPortNo)
				{
				case 1:
					SetTimer(30, 110, NULL);
					break;
				case 2:
					SetTimer(31, 140, NULL);
					break;
				case 3:
					SetTimer(32, 170, NULL);
					break;
				case 4:
					SetTimer(33, 200, NULL);
					break;
				}
				/*switch(stProcessCmd.nPortNo)
				{
				case 1:
					m_pPLCSignalCommand->EventSignalPCData1(TRUE);
					break;
				case 2:
					m_pPLCSignalCommand->EventSignalPCData2(TRUE);
					break;
				case 3:
					m_pPLCSignalCommand->EventSignalPCData3(TRUE);
					break;
				case 4:
					m_pPLCSignalCommand->EventSignalPCData4(TRUE);
					break;
				}
				EventSignalBitDataSend(nPLCNo);*/
			}
			break;
		}
 	}
	return true;
}

LRESULT CEQPLCDlg::OnPortEvent(WPARAM wParam, LPARAM lParam)
{
	int nPLCNo = (int)wParam;
	int nPortNo = (int)lParam;
	CString strTag;
	strTag.Format("U_%02d_PortDataUnit", nPLCNo+1);

	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Port Event - PLCNo : %d / PortNo : %d / Tag : %s"),
		nPLCNo, nPortNo, strTag);

	int nCnt = m_vtEQPLC.size();
	int i, nVarID;
	PLC::IPLC* pPLC = NULL;
	for(i = 0; i < nCnt; i++)
	{
		pPLC = m_vtEQPLC[i];
		if(0 == pPLC->GetTagName().Compare(strTag))
		{
			nVarID = i;
			break;
		}
	}
	if(i >= nCnt)
		return NULL;
	m_objEIP.receiveValues((char *)m_strEQIP.operator LPCTSTR(), (char *)strTag.operator LPCTSTR(), nVarID);
	return NULL;
}


LRESULT CEQPLCDlg::OnGlassInfoReq(WPARAM wParam, LPARAM lParam)
{
	int nPLCNo = (int)wParam;
	int nUnitNo = (int)lParam;
	CString strTag;
	CString str1="";
	CString str2="";
	strTag.Format("U_%02d_TransferGlassDataUnit%d", nPLCNo + 1, nUnitNo);

	CUtil::WriteLogFile(CABConfig::g_strLog, _T("Glass Data Request - PLCNo : %d / UnitNo : %d / Tag : %s"),
						nPLCNo, nUnitNo, strTag);
	
	int nCnt = m_vtEQPLC.size();
	int i, nVarID;
	PLC::IPLC* pPLC = NULL;
	for(i = 0; i < nCnt; i++)
	{
		pPLC = m_vtEQPLC[i];
		if(0 == pPLC->GetTagName().Compare(strTag))
		{
			nVarID = i;
			break;
		}
	}
	if(i >= nCnt)
	{
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("GlassData 누락! VarId : %i, 총사이즈 :nCnt"), i,nCnt);
		return NULL;
	}
	m_objEIP.receiveValues((char *)m_strEQIP.operator LPCTSTR(), (char *)strTag.operator LPCTSTR(), nVarID);
	return NULL;
}

void CEQPLCDlg::OnBnClickedCancel()
{
	this->ShowWindow(SW_HIDE);
}

LRESULT CEQPLCDlg::OnLC(WPARAM wParam, LPARAM lParam)
{
	CButton *pButton1 = (CButton*)GetDlgItem(IDC_LC_ON);
	CButton *pButton2 = (CButton*)GetDlgItem(IDC_LC_OFF);
	/*if(wParam ==1)
	{
		pButton1->SetCheck(TRUE);
		pButton2->SetCheck(FALSE);
		CPLCEventObjectUnit::m_bInitPort = TRUE;
		PostMessage(WM_EVENT_PORT, (WPARAM) 0, (LPARAM)1);

		CUtil::WriteLogFile(CABConfig::g_strLog, _T("Init WIPQTY Event"));
		m_strLog.Format( _T("Init WIPQTY Event"));
		m_ctrlLogList.AddString(m_strLog);

		Message::CMsgWIPQTYEvent* pInitWIPQTYEvent = new Message::CMsgWIPQTYEvent;
		memcpy(pInitWIPQTYEvent, &m_objInitWIPQTYEvent, sizeof(Message::CMsgWIPQTYEvent));


		CXMLMsg msg;
		msg.Load(pInitWIPQTYEvent);
		msg.SetSource(m_strEQName, "N/A");
		m_LCIFDlg.OnPLCEvent(msg);

	}
	if(wParam == 2)
	{
		CPLCEventObjectUnit::m_bInitPort = FALSE;
		pButton1->SetCheck(FALSE);
		pButton2->SetCheck(TRUE);
	}*/
	switch(wParam)
	{
	case 1:
		pButton1->SetCheck(TRUE);
		pButton2->SetCheck(FALSE);
		CPLCEventObjectUnit::m_bInitPort = TRUE;
		PostMessage(WM_EVENT_PORT, (WPARAM) 0, (LPARAM)1);
		break;
	case 2:
		CPLCEventObjectUnit::m_bInitPort = FALSE;
		pButton1->SetCheck(FALSE);
		pButton2->SetCheck(TRUE);
		break;
	default:
		return NULL;
		break;
	}
	return NULL;
}

void CEQPLCDlg::OnBnClickedRadioManual()
{
	/*m_pPLCSignalCommand->m_bCheck = FALSE;
	GetDlgItem(IDC_BUTTON_PORT1_ON)->EnableWindow(TRUE);
	GetDlgItem(IDC_BUTTON_PORT1_OFF)->EnableWindow(TRUE);
	GetDlgItem(IDC_BUTTON_PORT2_ON)->EnableWindow(TRUE);
	GetDlgItem(IDC_BUTTON_PORT2_OFF)->EnableWindow(TRUE);
	GetDlgItem(IDC_BUTTON_PORT3_ON)->EnableWindow(TRUE);
	GetDlgItem(IDC_BUTTON_PORT3_OFF)->EnableWindow(TRUE);
	GetDlgItem(IDC_BUTTON_PORT4_ON)->EnableWindow(TRUE);
	GetDlgItem(IDC_BUTTON_PORT4_OFF)->EnableWindow(TRUE);*/
}

void CEQPLCDlg::OnBnClickedRadioAuto()
{
	m_pPLCSignalCommand->m_bCheck = TRUE;
	GetDlgItem(IDC_BUTTON_PORT1_ON)->EnableWindow(FALSE);
	GetDlgItem(IDC_BUTTON_PORT1_OFF)->EnableWindow(FALSE);
	GetDlgItem(IDC_BUTTON_PORT2_ON)->EnableWindow(FALSE);
	GetDlgItem(IDC_BUTTON_PORT2_OFF)->EnableWindow(FALSE);
	GetDlgItem(IDC_BUTTON_PORT3_ON)->EnableWindow(FALSE);
	GetDlgItem(IDC_BUTTON_PORT3_OFF)->EnableWindow(FALSE);
	GetDlgItem(IDC_BUTTON_PORT4_ON)->EnableWindow(FALSE);
	GetDlgItem(IDC_BUTTON_PORT4_OFF)->EnableWindow(FALSE);
}

void CEQPLCDlg::OnBnClickedButtonPort1On()
{
	m_pPLCSignalCommand->m_bCheck = TRUE;
	m_pPLCSignalCommand->EventSignalUnitReport(0,TRUE);
	m_pPLCSignalCommand->m_bCheck = FALSE;
}

void CEQPLCDlg::OnBnClickedButtonPort1Off()
{
	m_pPLCSignalCommand->m_bCheck = TRUE;
	m_pPLCSignalCommand->EventSignalUnitReport(0,FALSE);
	m_pPLCSignalCommand->m_bCheck = FALSE;
}

void CEQPLCDlg::OnBnClickedButtonPort2On()
{
	m_pPLCSignalCommand->m_bCheck = TRUE;
	m_pPLCSignalCommand->EventSignalUnitReport(1,TRUE);
	m_pPLCSignalCommand->m_bCheck = FALSE;
}

void CEQPLCDlg::OnBnClickedButtonport2Off()
{
	m_pPLCSignalCommand->m_bCheck = TRUE;
	m_pPLCSignalCommand->EventSignalUnitReport(1,FALSE);
	m_pPLCSignalCommand->m_bCheck = FALSE;
}

void CEQPLCDlg::OnBnClickedButtonPort3On()
{
	m_pPLCSignalCommand->m_bCheck = TRUE;
	m_pPLCSignalCommand->EventSignalUnitReport(2,TRUE);
	m_pPLCSignalCommand->m_bCheck = FALSE;
}

void CEQPLCDlg::OnBnClickedButtonPort3Off()
{
	m_pPLCSignalCommand->m_bCheck = TRUE;
	m_pPLCSignalCommand->EventSignalUnitReport(2,FALSE);
	m_pPLCSignalCommand->m_bCheck = FALSE;
}

void CEQPLCDlg::OnBnClickedButtonPort4On()
{
	m_pPLCSignalCommand->m_bCheck = TRUE;
	m_pPLCSignalCommand->EventSignalUnitReport(3,TRUE);
	m_pPLCSignalCommand->m_bCheck = FALSE;
}

void CEQPLCDlg::OnBnClickedButtonport4Off()
{
	m_pPLCSignalCommand->m_bCheck = TRUE;
	m_pPLCSignalCommand->EventSignalUnitReport(3,FALSE);
	m_pPLCSignalCommand->m_bCheck = FALSE;
}
void CEQPLCDlg::OnWindowPosChanging(WINDOWPOS* lpwndpos)
{
	if(m_bvisible == FALSE)
	{
		lpwndpos->flags &= ~SWP_SHOWWINDOW;
	}
	__super::OnWindowPosChanging(lpwndpos);
}

void CEQPLCDlg::OnBnClickedButtonOnoff()
{
	/*if(m_bPush == FALSE)
	{
		m_pPLCSignalCommand->EventSignalAutoCommand(TRUE);
		m_bPush = TRUE;

	}
	else
	{
		m_pPLCSignalCommand->EventSignalAutoCommand(FALSE);
		m_bPush = FALSE;
	}
	EventSignalBitDataSend(0);*/	
}

void CEQPLCDlg::DataMessageChange(int nPLCNo, int nNum, CString strTerminal, CString strOPCall)
{
	PLC::CPLCSigWordCommand::EQ_CMD stEQCmd;
	memset(&stEQCmd, 0x00, sizeof(stEQCmd));
	stEQCmd.nIDnNo = nNum;
	strcpy(stEQCmd.szTerminalText, strTerminal.operator LPCTSTR());
	strcpy(stEQCmd.szOPCallText, strOPCall.operator LPCTSTR());

	m_pPLCSigWordCommand->SetEQCmd(stEQCmd);
	if(0 < strTerminal.GetLength())
	{
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("PC Teminal Message Signal : TRUE"));
		m_pPLCSignalCommand->EventSignalTerminalMsgCmd(TRUE);
	}
	if(0 < strOPCall.GetLength())
	{
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("PC OPCALL Message Signal : TRUE"));
		m_pPLCSignalCommand->EventSignalOPCallCmd(TRUE);
	}
	EventSigWordData1Send(nPLCNo);
	EventSignalBitDataSend(nPLCNo);
}

void CEQPLCDlg::ConnectionEvent(int nResult)
{
	CMsgConnectionEvent* pMsg = new CMsgConnectionEvent();

	pMsg->m_nResult = nResult;

	CXMLMsg msg;
	msg.Load(pMsg);
	msg.SetSource(m_strEQName, "N/A");
	m_LCIFDlg.OnPLCEvent(msg);
}