#pragma once

// 컴퓨터에서 Microsoft Visual C++를 사용하여 생성한 IDispatch 래퍼 클래스입니다.

// 참고: 이 파일의 내용을 수정하지 마십시오. Microsoft Visual C++에서
//  이 클래스를 다시 생성할 때 수정한 내용을 덮어씁니다.

/////////////////////////////////////////////////////////////////////////////
// CCorenetlibctrl1 래퍼 클래스입니다.

class CCorenetlibctrl1 : public CWnd
{
protected:
	DECLARE_DYNCREATE(CCorenetlibctrl1)
public:
	CLSID const& GetClsid()
	{
		static CLSID const clsid
			= { 0x20605580, 0x2FE9, 0x4CC1, { 0x95, 0x1E, 0x2A, 0xD2, 0x10, 0xD8, 0xC9, 0xFB } };
		return clsid;
	}
	virtual BOOL Create(LPCTSTR lpszClassName, LPCTSTR lpszWindowName, DWORD dwStyle,
						const RECT& rect, CWnd* pParentWnd, UINT nID, 
						CCreateContext* pContext = NULL)
	{ 
		return CreateControl(GetClsid(), lpszWindowName, dwStyle, rect, pParentWnd, nID); 
	}

    BOOL Create(LPCTSTR lpszWindowName, DWORD dwStyle, const RECT& rect, CWnd* pParentWnd, 
				UINT nID, CFile* pPersist = NULL, BOOL bStorage = FALSE,
				BSTR bstrLicKey = NULL)
	{ 
		return CreateControl(GetClsid(), lpszWindowName, dwStyle, rect, pParentWnd, nID,
		pPersist, bStorage, bstrLicKey); 
	}

// 특성입니다.
public:


// 작업입니다.
public:

// _DCoreNetLib

// Functions
//

	long Start()
	{
		long result;
		InvokeHelper(0x4, DISPATCH_METHOD, VT_I4, (void*)&result, NULL);
		return result;
	}
	long SendString(LPCTSTR sendMsg)
	{
		long result;
		static BYTE parms[] = VTS_BSTR ;
		InvokeHelper(0x5, DISPATCH_METHOD, VT_I4, (void*)&result, parms, sendMsg);
		return result;
	}
	CString GetString(long nMsgID)
	{
		CString result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x6, DISPATCH_METHOD, VT_BSTR, (void*)&result, parms, nMsgID);
		return result;
	}
	long Stop()
	{
		long result;
		InvokeHelper(0x7, DISPATCH_METHOD, VT_I4, (void*)&result, NULL);
		return result;
	}

// Properties
//

CString GetIP()
{
	CString result;
	GetProperty(0x1, VT_BSTR, (void*)&result);
	return result;
}
void SetIP(CString propVal)
{
	SetProperty(0x1, VT_BSTR, propVal);
}
long GetPort()
{
	long result;
	GetProperty(0x2, VT_I4, (void*)&result);
	return result;
}
void SetPort(long propVal)
{
	SetProperty(0x2, VT_I4, propVal);
}
BOOL GetActive()
{
	BOOL result;
	GetProperty(0x3, VT_BOOL, (void*)&result);
	return result;
}
void SetActive(BOOL propVal)
{
	SetProperty(0x3, VT_BOOL, propVal);
}
BOOL GetLogEvent()
{
	BOOL result;
	GetProperty(0x9, VT_BOOL, (void*)&result);
	return result;
}
void SetLogEvent(BOOL propVal)
{
	SetProperty(0x9, VT_BOOL, propVal);
}
BOOL GetLogMesgSummary()
{
	BOOL result;
	GetProperty(0xa, VT_BOOL, (void*)&result);
	return result;
}
void SetLogMesgSummary(BOOL propVal)
{
	SetProperty(0xa, VT_BOOL, propVal);
}
long GetSendTimeOut()
{
	long result;
	GetProperty(0xc, VT_I4, (void*)&result);
	return result;
}
void SetSendTimeOut(long propVal)
{
	SetProperty(0xc, VT_I4, propVal);
}
BOOL GetLogMesgDetail()
{
	BOOL result;
	GetProperty(0xd, VT_BOOL, (void*)&result);
	return result;
}
void SetLogMesgDetail(BOOL propVal)
{
	SetProperty(0xd, VT_BOOL, propVal);
}
BOOL GetEstablished()
{
	BOOL result;
	GetProperty(0xe, VT_BOOL, (void*)&result);
	return result;
}
void SetEstablished(BOOL propVal)
{
	SetProperty(0xe, VT_BOOL, propVal);
}
CString GetLogPath()
{
	CString result;
	GetProperty(0xf, VT_BSTR, (void*)&result);
	return result;
}
void SetLogPath(CString propVal)
{
	SetProperty(0xf, VT_BSTR, propVal);
}


};
