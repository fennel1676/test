// SingleThread.cpp: implementation of the CSingleThread class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "SingleThread.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CSingleThread::CSingleThread()
{

}

CSingleThread::~CSingleThread()
{

}

BOOL CSingleThread::Start_Thread()
{
	DWORD	dwThreadID = 0;
	m_hThread = ::CreateEvent(0, 0, 0, 0);
	if(NULL == m_hThread)	return FALSE;

	if(NULL == ::CreateThread(NULL, 0, CSingleThread::threadFunc, this, 0, &dwThreadID))
	{
		::CloseHandle(m_hThread);
		return FALSE;
	}

	return TRUE;
}

void CSingleThread::Stop_Thread()
{
	if(NULL != m_hThread)
	{
		m_hHandleKillEvent = ::CreateEvent( 0, 0, 0, 0 );
		::SetEvent(m_hThread);
		::WaitForSingleObject(m_hHandleKillEvent, 5000);
		::CloseHandle(m_hThread);
		::CloseHandle(m_hHandleKillEvent);
		m_hThread = NULL;
		m_hHandleKillEvent = NULL;
	}
}

DWORD _stdcall CSingleThread::threadFunc(LPVOID lParam)
{
	CSingleThread *pDlg = (CSingleThread *)lParam;
	pDlg->ThreadFunc();
	::SetEvent(pDlg->m_hHandleKillEvent);
	TRACE("ThreadFunc ()\n");
	return 0;
}
