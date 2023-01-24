// LCIFDlg.cpp : ���� �����Դϴ�.
//

#include "stdafx.h"
#include "EQPLC.h"
#include "LCIFDlg.h"
#include "EQPLCDlg.h"

#include "XMLMsg.h"

// CLCIFDlg ��ȭ �����Դϴ�.

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


// CLCIFDlg �޽��� ó�����Դϴ�.

BOOL CLCIFDlg::Create(CWnd* pParentWnd)
{
	// TODO: ���⿡ Ư��ȭ�� �ڵ带 �߰� ��/�Ǵ� �⺻ Ŭ������ ȣ���մϴ�.
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
	m_CoreNet.SetActive(TRUE); //�׻� EQPLC �� Active Mode
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
	// TODO: ���⿡ �޽��� ó���� �ڵ带 �߰��մϴ�.
	m_bConnect = false;
	::PostMessage(m_pParent->m_hWnd, WMU_LC_EVENT, LC_DISCONNECT, 0L);
}

void CLCIFDlg::OnConnectionCoreNet()
{
	// TODO: ���⿡ �޽��� ó���� �ڵ带 �߰��մϴ�.
	m_bConnect = true;
	::PostMessage(m_pParent->m_hWnd, WMU_LC_EVENT, LC_CONNECT, 0L);
}

void CLCIFDlg::OnReceiveCoreNet(long nMsgID)
{
	// TODO: ���⿡ �޽��� ó���� �ڵ带 �߰��մϴ�.
	CString strXML = m_CoreNet.GetString(nMsgID);

	// XML Log ǥ��
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

	// TODO:  ���⿡ �߰� �ʱ�ȭ �۾��� �߰��մϴ�.

	return TRUE;  // return TRUE unless you set the focus to a control
	// ����: OCX �Ӽ� �������� FALSE�� ��ȯ�ؾ� �մϴ�.
}
