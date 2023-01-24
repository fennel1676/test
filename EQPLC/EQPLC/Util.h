// Util.h: interface for the CUtil class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_UTIL_H__2699FD55_2F0F_4761_93E1_66969749FC26__INCLUDED_)
#define AFX_UTIL_H__2699FD55_2F0F_4761_93E1_66969749FC26__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#define		LOGFILE		CUtil::WriteLogFile


class CUtil  
{
public:
	static HANDLE	hConsole;
	static BOOL		bLogFileDateFlag;	//	�α� ���ϸ��� ��¥ ǥ����ġ(FALSE:��, TRUE:��)
	static BOOL		bCSVFileDateFlag;	//	CSV ���ϸ��� ��¥ ǥ����ġ(FALSE:��, TRUE:��)
	static BOOL		bFile;	//	�α� ����� ���ϸ� ǥ��
	static BOOL		bLine;	//	�α� ����� ������ ���μ� ǥ��
	static void ShowLine(BOOL bShow);
	static void ShowFile(BOOL bShow);
	static void ShowConsole(BOOL bShow);
	static void WriteLogFile(const char *pszLogFileName, const char *sfmt, ...);
	static void WriteLogFile(CString &strLogFileName, const char *sfmt, ...);
	static void WriteCSVFile(const char *pszCSVFileName, const char *sfmt, ...);
	static void WriteCSVFile(CString &strCSVFileName, const char *sfmt, ...);
	static void DeleteLogFile(CString strLogPath, int nValue); //Log����
	static void WriteDataFile(const char *pszDataFileName, const char *pszData, int nDataCnt);
	static void SetLogFileDateFlag(BOOL bFlag = FALSE){bLogFileDateFlag = bFlag;}
	static void SetCSVFileDateFlag(BOOL bFlag = FALSE){bCSVFileDateFlag = bFlag;}
	static void IPC_Send(const char *szCaption, void *pData, int nSize);
	static long Str2Hex(const char *szHex, int nCnt);
	static CString GetFullPathName(CString strPath);
	static int DeleteFilesInSameDir(CString strFullDirectoryPath, CString strFind, int nDaysAgo=0);
	static bool IsExistDirectory(CString strFullPath);
	static BOOL TickCheck(DWORD dPeriode, DWORD dLastTime);
	static BOOL ABPLCStrSwap(char *szOutStr, int nLength);
	static BOOL ABPLCBinSwap(char *szOutStr, int nLength);		
public:
	CUtil(){}
	~CUtil(){}
};

#endif // !defined(AFX_UTIL_H__2699FD55_2F0F_4761_93E1_66969749FC26__INCLUDED_)
