#pragma once
#include "corenetlibctrl1.h"
#include "afxwin.h"


#define WMU_LC_EVENT		WM_USER + 111

enum ELC_EVENT
{
	LC_CONNECT			= 1,
	LC_DISCONNECT		= 2,
	LC_PROCESS_CMD		= 5,
	LC_EQ_CMD			= 6,
	LC_UNIT_CMD			= 7,
	LC_MAT_CMD			= 8,
	LC_PROD_PLAN		= 9,
	LC_ALIVE			= 10,
	LC_FLOW_CMD			= 12,
	LC_DATETIME_CMD		= 13,
	LC_TEST_GET_GLASS	= 14,		// test (Read glass Info)
	LC_TEST_READ		= 15,
	LC_TEST_WRITE		= 16,
	LC_TEST_GROUP_READ	= 17,      // test (Read Flow Group)
	LC_TEST_RECIPE_READ = 18,     // test (Read Flow Recipe)
	LC_MANUALDPH_CMD	= 19,
	LC_SAMPLEING_DEF_CMD= 20,
	LC_ONLINEPARAM_CMD	= 21,     
	LC_TEST_GROUP_WRITE = 22,    // test (write Flow Group)
	LC_TEST_RECIPE_WRITE= 23,  // test (write Flow Recipe)
	LC_JUDGEFLOW_CMD	= 25,
	LC_TEST_SET_GLASS   = 26,     // test (write glass Info)
	LC_EQCONSTANT_CMD   = 27,
	LC_ALARM_CTRL_CMD	= 28,
	LC_EQ_CONSTANT_CMD	= 29
};


// CLCIFDlg 대화 상자입니다.
class CXMLMsg;
class CEQPLCDlg;

class CLCIFDlg : public CDialog
{
	DECLARE_DYNAMIC(CLCIFDlg)

public:
	CLCIFDlg(CWnd* pParent = NULL);   // 표준 생성자입니다.
	virtual ~CLCIFDlg();

// 대화 상자 데이터입니다.
	enum { IDD = IDD_LC_DIALOG };

	enum { CORENET_CONNECT_OK = -9980, CORENET_CONNECT_FAIL = -9981, CORENET_ALREADY_CONNECTED = -9998, CORENET_PARAMETER_INVALID = -9999 };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.

	DECLARE_MESSAGE_MAP()
public:
	virtual BOOL Create(CWnd* pParentWnd = NULL);

public:
//-. override default Action for Enter/ESC key
	void OnOK() {}
	void OnCancel() { ShowWindow(SW_HIDE); }

public:
//-. CoreNet Connection Parameter
	CString m_sIP;
	int m_nPort;
//-. Corenet Connection
	bool m_bConnect;
public:
	long Start();
	long Stop();

	bool CLCIFDlg::OnPLCEvent(CXMLMsg& msg);
public:
	CCorenetlibctrl1 m_CoreNet;
public:
	DECLARE_EVENTSINK_MAP()
public: 
//-. CoreNet Event
	void OnCloseCoreNet();
	void OnConnectionCoreNet();
	void OnReceiveCoreNet(long nMsgID);
private:
	void SendMsgToParent(UINT msg, WPARAM wParam, LPARAM lParam);
	bool SendMsgToLC(const CString& msg);
	void SetParentPtr(CWnd* pParent);
private:
	CEQPLCDlg*	m_pParent;
public:
	virtual BOOL OnInitDialog();
};
