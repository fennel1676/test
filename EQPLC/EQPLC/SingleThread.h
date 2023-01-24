// SingleThread.h: interface for the CSingleThread class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_SINGLETHREAD_H__DE1597A3_F03F_4C16_AFC2_07DE65D218E6__INCLUDED_)
#define AFX_SINGLETHREAD_H__DE1597A3_F03F_4C16_AFC2_07DE65D218E6__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class CSingleThread  
{
public:
	CSingleThread();
	virtual ~CSingleThread();

public:
	HANDLE		m_hHandleKillEvent;
	HANDLE		m_hThread;
	DWORD		m_dwThreadID;

	BOOL Start_Thread();
	void Stop_Thread();

	virtual void ThreadFunc() = 0;
	static DWORD _stdcall threadFunc(LPVOID lParam);
};

#endif // !defined(AFX_SINGLETHREAD_H__DE1597A3_F03F_4C16_AFC2_07DE65D218E6__INCLUDED_)
