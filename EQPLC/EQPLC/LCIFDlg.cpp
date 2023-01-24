// LCIFDlg.cpp : 구현 파일입니다.
//

#include "stdafx.h"
#include "EQPLC.h"
#include "LCIFDlg.h"
#include "EQPLCDlg.h"

#include "XMLMsg.h"

// CLCIFDlg 대화 상자입니다.

IMPLEMENT_DYNAMIC(CLCIFDlg, CDialog)

CLCIFDlg::CLCIFDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CLCIFDlg::IDD, pParent), m_nPort(0), m_bConnect(false)
{
	SetParentPtr(pParent);
}

CLCIFDlg::~CLCIFDlg()
{
}

void CLCIFDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_CORENETLIBCTRL1, m_CoreNet);
	//DDX_Control(pDX, IDC_MSG_LIST, m_listMessage);
}


BEGIN_MESSAGE_MAP(CLCIFDlg, CDialog)
END_MESSAGE_MAP()


// CLCIFDlg 메시지 처리기입니다.

BOOL CLCIFDlg::Create(CWnd* pParentWnd)
{
	// TODO: 여기에 특수화된 코드를 추가 및/또는 기본 클래스를 호출합니다.
	SetParentPtr(pParentWnd);

	return CDialog::Create(IDD, pParentWnd);
}
void CLCIFDlg::SetParentPtr(CWnd* pParent)
{
	if(pParent != NULL)
	{
		if(CEQPLCDlg* pDlg = dynamic_cast<CEQPLCDlg*>(pParent))
			m_pParent = pDlg;
	}
}

long CLCIFDlg::Start()
{
	if(0 == m_nPort || m_sIP.IsEmpty())
		return CORENET_PARAMETER_INVALID;

	if(m_bConnect)
		return CORENET_ALREADY_CONNECTED;

	m_CoreNet.SetIP(m_sIP);
	m_CoreNet.SetActive(TRUE); //항상 EQPLC 가 Active Mode
	m_CoreNet.SetLogEvent(FALSE);
	m_CoreNet.SetLogMesgDetail(FALSE);
	m_CoreNet.SetLogMesgSummary(FALSE);
	m_CoreNet.SetLogPath("C:\\");
		
	m_CoreNet.SetPort(m_nPort);	
	long nRet = m_CoreNet.Start();

	if(CORENET_CONNECT_OK != nRet)
		return nRet;

	return 0;
}


long CLCIFDlg::Stop()
{
	m_CoreNet.Stop();
	m_bConnect = false;
	return 0;
}

BEGIN_EVENTSINK_MAP(CLCIFDlg, CDialog)
	ON_EVENT(CLCIFDlg, IDC_CORENETLIBCTRL1, 1, CLCIFDlg::OnCloseCoreNet, VTS_NONE)
	ON_EVENT(CLCIFDlg, IDC_CORENETLIBCTRL1, 2, CLCIFDlg::OnConnectionCoreNet, VTS_NONE)
	ON_EVENT(CLCIFDlg, IDC_CORENETLIBCTRL1, 3, CLCIFDlg::OnReceiveCoreNet, VTS_I4)
END_EVENTSINK_MAP()

void CLCIFDlg::OnCloseCoreNet()
{
	// TODO: 여기에 메시지 처리기 코드를 추가합니다.
	m_bConnect = false;
	::PostMessage(m_pParent->m_hWnd, WMU_LC_EVENT, LC_DISCONNECT, 0L);
}

void CLCIFDlg::OnConnectionCoreNet()
{
	// TODO: 여기에 메시지 처리기 코드를 추가합니다.
	m_bConnect = true;
	::PostMessage(m_pParent->m_hWnd, WMU_LC_EVENT, LC_CONNECT, 0L);
}

void CLCIFDlg::OnReceiveCoreNet(long nMsgID)
{
	// TODO: 여기에 메시지 처리기 코드를 추가합니다.
	CString strXML = m_CoreNet.GetString(nMsgID);

	// XML Log 표시
	if(CABConfig::g_nXML == 1)
	{
		CUtil::WriteLogFile(CABConfig::g_strXMLlog,_T("FromLC=========================")+strXML);
	}
	CXMLMsg msg;
	if(0 == msg.Load(strXML))
	{
		if(NULL != m_pParent && ::IsWindow(m_hWnd))
		{
			m_pParent->OnLCEvent(msg);
		}
	}
}

void CLCIFDlg::SendMsgToParent(UINT msg, WPARAM wParam, LPARAM lParam)
{
	if(NULL != m_pParent && ::IsWindow(m_hWnd))
	{
		::PostMessage(m_pParent->m_hWnd, msg, wParam, lParam);
	}
}

bool CLCIFDlg::SendMsgToLC(const CString& msg)
{
	if(m_bConnect && !msg.IsEmpty())
	{
		m_CoreNet.SendString(msg);
		return true;
	}
	return false;
}

bool CLCIFDlg::OnPLCEvent(CXMLMsg& msg)
{
	CString strSendMsg = msg.GetDoc();
	if(!strSendMsg.IsEmpty())
	{
		if(CABConfig::g_nXML == 1)
		{
			CUtil::WriteLogFile(CABConfig::g_strXMLlog,_T("ToLC=========================")+strSendMsg);
		}
		return SendMsgToLC(strSendMsg);
	}
	return false;
}

BOOL CLCIFDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// TODO:  여기에 추가 초기화 작업을 추가합니다.

	return TRUE;  // return TRUE unless you set the focus to a control
	// 예외: OCX 속성 페이지는 FALSE를 반환해야 합니다.
}
