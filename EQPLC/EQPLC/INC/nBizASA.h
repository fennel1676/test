//nBizASA.h

#define nADAPTER_API __declspec(dllimport)

#define INT8            char
#define UINT8           unsigned char
#define INT16           signed short
#define UINT16          unsigned short
#define INT32           signed int
#define UINT32          unsigned int

typedef void NewDataCallBackType( int variableId );		    /* Callback function to be called in case of any new data written into a table */
typedef void StatusChangeCallBackType( int variableId );	/* Callback function to be called in case of change of state for the variable */

typedef enum tagConnectionType
{
  UnusedConnType,
  UnknownConnType,
  Class1Producing,
  Class1Consuming,
  Class3Serving,
  Class3Client,
  TimeOutConnType
} ConnectionType;

typedef enum tagTransportType
{
  NoneTT,
  CyclicTT,
  ChangeOfStateTT,
  ApplicationTriggeredTT
} TransportType;

// COMMANDS
////////////////////////////////////////////////////////////////////////////////
/* Initializes internal structures with local variables/types based on the config file. 
 * Returns 0 on success, or negative error code.
 * Provided callback will be called any time a new value has been writen to a local variable, 
 * either by class1 consumed connection or received class 3 unconnected message
 * This function has to be called before any other.
 * Function starts class1 connections, but it does not wait until all of them are established.
 */
extern  nADAPTER_API int n_EtAdInitialize( char* hostIP, char* configFileName, NewDataCallBackType* pfn1Event, StatusChangeCallBackType* pfn2Event );

////////////////////////////////////////////////////////////////////////////////
// QUERIES - Variables
/* Returns number of all local tags/tables. */
extern  nADAPTER_API int n_EtAdGetNumberOfAllVariables();

////////////////////////////////////////////////////////////////////////////////
/* Copies up to size variable ids into provided buffer.
 * Returns number of variable ids copied into buff.
 */
extern nADAPTER_API int n_EtAdGetAllVariableIds( int *buff, int size );

////////////////////////////////////////////////////////////////////////////////
/* Returns base type name for the given variable.
 * Currently supported base types are: 
 *  DINT,INT,SINT,BOOL (4bytes, 2 bytes, 1 byte, 1 bit)
 *  REAL
 */
extern nADAPTER_API char* n_EtAdGetVariableBaseTypeName( int variableId );

////////////////////////////////////////////////////////////////////////////////
/* Returns name of the variable */
extern nADAPTER_API const char* n_EtAdGetVariableName( int variableId );

////////////////////////////////////////////////////////////////////////////////
/* Returns number of variable elements. It is 1 for single valued, or array size for arrays.  */
extern nADAPTER_API int n_EtAdGetVariableLength( int variableId );

////////////////////////////////////////////////////////////////////////////////
/* Returns TRUE if the variable is produced */
extern nADAPTER_API BOOL n_EtAdIsVariableProduced( int variableId );

////////////////////////////////////////////////////////////////////////////////
/* Returns TRUE if the variable is consumed */
extern nADAPTER_API BOOL n_EtAdIsVariableConsumed( int variableId );

////////////////////////////////////////////////////////////////////////////////
/* Returns TRUE if the variable is consumed and there is a live class1 connection. */
extern nADAPTER_API BOOL n_EtAdIsVariableOnline( int variableId );

////////////////////////////////////////////////////////////////////////////////
/* Returns number of open connections to a produced variable.
 * Return 0 if variable is not produced, or -1 if there is no such variable. */
extern nADAPTER_API int n_EtAdGetNumberOfConnections( int variableId );

////////////////////////////////////////////////////////////////////////////////
/* Reads value(s) from an integer based DINT variable. 
 * If variable is consumed the last received values from the producer are returned.
 * If successful the function reads all variable elements up to the given size pl and returns number of elements read.
 */
extern nADAPTER_API int n_EtAdReadVariableDintValue( int variableId, INT32* pv, int pl );

////////////////////////////////////////////////////////////////////////////////
/* Reads value(s) from an integer based INT variable. 
 * If variable is consumed the last received values from the producer are returned.
 * If successful the function reads all variable elements up to the given size pl and returns number of elements read.
 */
extern nADAPTER_API int n_EtAdReadVariableIntValue( int variableId, INT16* pv, int pl );


////////////////////////////////////////////////////////////////////////////////
/* Reads value(s) from an integer based SINT variable. 
 * If variable is consumed the last received values from the producer are returned.
 * If successful the function reads all variable elements up to the given size pl and returns number of elements read.
 */
extern nADAPTER_API int n_EtAdReadVariableSintValue( int variableId, INT8* pv, int pl );

////////////////////////////////////////////////////////////////////////////////
/* Reads value(s) from an integer based BOOL variable. 
 * If variable is consumed the last received values from the producer are returned.
 * If successful the function reads all variable elements up to the given size pl and returns number of elements read.
 */
//extern nADAPTER_API int n_EtAdReadVariableBoolValue( int variableId, BOOL* pv, int pl );


////////////////////////////////////////////////////////////////////////////////
/* Reads value(s) from a float based (REAL) variable.
 * If variable is consumed the last received values from the producer are returned.
 * If successfull function reads all variable elements up to the given size pl and returns number of elements read.
 */
extern nADAPTER_API int n_EtAdReadVariableRealValue( int variableId, float* pv, int pl );

////////////////////////////////////////////////////////////////////////////////
/* Write given DINT values into variable elements. Returns number of actually written elements.
 * If variable is produced values are copied into local buffer, and Class1 connection based on their transport types 
 * transmits data to all consumers.
 * NOTE: Writing to a local consumed variable will fail.
 */
extern nADAPTER_API int n_EtAdWriteVariableDintValue( int variableId, INT32 *pv, int pl );

////////////////////////////////////////////////////////////////////////////////
/* Write given INT values into variable elements. Returns number of actually written elements.
 * If variable is produced values are copied into local buffer, and Class1 connection based on their transport types 
 * transmits data to all consumers.
 * NOTE: Writing to a local consumed variable will fail.
 */
extern nADAPTER_API int n_EtAdWriteVariableIntValue( int variableId, INT16 *pv, int pl );

////////////////////////////////////////////////////////////////////////////////
/* Write given SINT values into variable elements. Returns number of actually written elements.
 * If variable is produced values are copied into local buffer, and Class1 connection based on their transport types 
 * transmits data to all consumers.
 * NOTE: Writing to a local consumed variable will fail.
 */
extern nADAPTER_API int n_EtAdWriteVariableSintValue( int variableId, INT8* pv, int pl );

////////////////////////////////////////////////////////////////////////////////
/* Write given BOOL values into variable elements. Returns number of actually written elements.
 * If variable is produced values are copied into local buffer, and Class1 connection based on their transport types 
 * transmits data to all consumers.
 * NOTE: Writing to a local consumed variable will fail.
 */
extern nADAPTER_API int n_EtAdWriteVariableBoolValue( int variableId, BOOL* pv, int pl );

////////////////////////////////////////////////////////////////////////////////
/* Write given float values into variable elements. Returns number of actually written elements.
 * If variable is produced values are copied into local buffer, and Class1 connection based on their transport types 
 * transmits data to all consumers.
 * NOTE: Writing to a local consumed variable will fail.
 */
extern nADAPTER_API int n_EtAdWriteVariableRealValue( int variableId, float* pv, int pl );

////////////////////////////////////////////////////////////////////////////////
/* Sends provided DINT values to a remote ethernet ip controller as an unconnected message.
   ioAddress is IOAddress of the external controller,
   varName is the name of the variable on the external controller.
   pl specifies the size of the value buffer pv.
   If pl is greater than real size of the array, only values up to the real size of the array will be written.
   Returns 0 on success, or negative value on any failure.
   NOTE: Writing values into consumed variables is not allowed.
 */
extern nADAPTER_API int n_EtAdSendVariableDintValue( char* ioAddress, char* varName, INT32* pv, int pl );

////////////////////////////////////////////////////////////////////////////////
/* Sends provided INT values to a remote ethernet ip controller as an unconnected message.
   ioAddress is IOAddress of the external controller,
   varName is the name of the variable on the external controller.
   pl specifies the size of the value buffer pv.
   If pl is greater than real size of the array, only values up to the real size of the array will be written.
   Returns 0 on success, or negative value on any failure.
   NOTE: Writing values into consumed variables is not allowed.
 */
extern nADAPTER_API int n_EtAdSendVariableIntValue( char* ioAddress, char* varName, INT16* pv, int pl );

////////////////////////////////////////////////////////////////////////////////
/* Sends provided SINT values to a remote ethernet ip controller as an unconnected message.
   ioAddress is IOAddress of the external controller,
   varName is the name of the variable on the external controller.
   pl specifies the size of the value buffer pv.
   If pl is greater than real size of the array, only values up to the real size of the array will be written.
   Returns 0 on success, or negative value on any failure.
   NOTE: Writing values into consumed variables is not allowed.
 */
extern nADAPTER_API int n_EtAdSendVariableSintValue( char* ioAddress, char* varName, INT8* pv, int pl );

////////////////////////////////////////////////////////////////////////////////
/* Sends provided BOOL values to a remote ethernet ip controller as an unconnected message.
   ioAddress is IOAddress of the external controller,
   varName is the name of the variable on the external controller.
   pl specifies the size of the value buffer pv.
   If pl is greater than real size of the array, only values up to the real size of the array will be written.
   Returns 0 on success, or negative value on any failure.
   NOTE: Writing values into consumed variables is not allowed.
 */
//extern nADAPTER_API int n_EtAdSendVariableBoolValue(char* ioAddress, char* varName, BOOL* pv, int pl );

////////////////////////////////////////////////////////////////////////////////
/* Sends provided REAL values to a remote ethernet ip controller as an unconnected message.
   ioAddress is IOAddress of the external controller,
   varName is the name of the variable on the external controller.
   pl specifies the size of the value buffer pv.
   If pl is greater than real size of the array, only values up to the real size of the array will be written.
   Returns 0 on success, or negative value on any failure.
   NOTE: Writing values into consumed variables is not allowed.
 */
extern nADAPTER_API int n_EtAdSendVariableRealValue(char* ioAddress, char* varName, float* pv, int pl );

////////////////////////////////////////////////////////////////////////////////
/* Sends unconnected request to read a DINT based variable values from remote ethernet ip controller.
   ioAddress is IOAddress of the external controller
   varName is the name of the variable on the external controller.
   pl specifies the size of value buffer pv.
   If pl is smaller than real size of the array, only values up to the real size of the array will be received.
   Returns number of actually read elements.
 */
extern nADAPTER_API int n_EtAdReceiveVariableDintValue(char* ioAddress, char* varName, INT32* pv, int pl );

////////////////////////////////////////////////////////////////////////////////
/* Sends unconnected request to read a INT based variable values from remote ethernet ip controller.
   ioAddress is IOAddress of the external controller
   varName is the name of the variable on the external controller.
   pl specifies the size of value buffer pv.
   If pl is smaller than real size of the array, only values up to the real size of the array will be received.
   Returns number of actually read elements.
 */
extern nADAPTER_API int n_EtAdReceiveVariableIntValue( char* ioAddress, char* varName, INT16* pv, int pl );

////////////////////////////////////////////////////////////////////////////////
/* Sends unconnected request to read a SINT based variable values from remote ethernet ip controller.
   ioAddress is IOAddress of the external controller
   varName is the name of the variable on the external controller.
   pl specifies the size of value buffer pv.
   If pl is smaller than real size of the array, only values up to the real size of the array will be received.
   Returns number of actually read elements.
 */
extern nADAPTER_API int n_EtAdReceiveVariableSintValue( char* ioAddress, char* varName, INT8* pv, int pl );

////////////////////////////////////////////////////////////////////////////////
/* Sends unconnected request to read a BOOL based variable values from remote ethernet ip controller.
   ioAddress is IOAddress of the external controller
   varName is the name of the variable on the external controller.
   pl specifies the size of value buffer pv.
   If pl is smaller than real size of the array, only values up to the real size of the array will be received.
   Returns number of actually read elements.
 */
extern nADAPTER_API int n_EtAdReceiveVariableBoolValue( char* ioAddress, char* varName, BOOL* pv, int pl );

////////////////////////////////////////////////////////////////////////////////
/* Sends unconnected request to read REAL values from remote ethernet ip controller.
   ioAddress is IOAddress of the external controller
   varName is the name of the variable on the external controller.
   pl specifies the size of value buffer pv.
   If pl is smaller than real size of the array, only values up to the real size of the array will be received.
   Returns number of actually read elements.
 */
extern nADAPTER_API int n_EtAdReceiveVariableRealValue( char* ioAddress, char* varName, float* pv, int pl );

////////////////////////////////////////////////////////////////////////////////
/*
  Sends Forward Open request to a remote ethernet ip node
   ioAddress is IOAddress of the external controller
   rate is producing/consuming rate in millis
  Returns connection instance if a connection is opened, or negative error code:
    -1: empty ioAddress
    -2: no available class3 connections
    -3: failed to allocate memory for an internal structure
    -4: EtIPOpenConnection return error code
    -5: Error response to Forward Open Request
 */
extern nADAPTER_API int n_EtAdOpenClass3Connection( char* ioAddress, int rate );

////////////////////////////////////////////////////////////////////////////////
/*
  Use open connection to send request to read DINT values from remote ethernet ip controller.
    connectionId is a connection instance as received from EtAdOpenClass3Connection
    srcVarName is a source variable name on the remote node
    srcVarLen represents number of array elements to be received, local var shall be at least of that size.
    Size of remote var (srcVarName) is not known, it want be checked.
    If srcVarLen is smaller than real size of source or destination array, only srcVarLen values will be received.
    An warn message will be logged, if during runtime there are not enough values comming from class3 connection 
  Returns 0 on success or negative error code:
    -1: illegal connectionId
    -2: illegal destVarId
    -3: destVarId does not have enough elements (srcVarLen)    
    -4: empty srcVarName
    -5: illegal srcVarLen 1..120
    -6: failed to set class3 datatable read request
*/
extern nADAPTER_API int n_EtAdReceiveClass3VariableDintValue( int connectionId, char* srcVarName, int srcVarLen, int destVarId );

////////////////////////////////////////////////////////////////////////////////
/*
  Use open connection to send request to read INT values from remote ethernet ip controller.
    connectionId is a connection instance as received from EtAdOpenClass3Connection
    srcVarName is a source variable name on the remote node
    srcVarLen represents number of array elements to be received, local var shall be at least of that size.
    Size of remote var (srcVarName) is not known, it want be checked.
    If srcVarLen is smaller than real size of source or destination array, only srcVarLen values will be received.
    An warn message will be logged, if during runtime there are not enough values comming from class3 connection 
  Returns 0 on success or negative error code:
    -1: illegal connectionId
    -2: illegal destVarId
    -3: destVarId does not have enough elements (srcVarLen)    
    -4: empty srcVarName
    -5: illegal srcVarLen 1..240
    -6: failed to set class3 datatable read request
*/
extern nADAPTER_API int n_EtAdReceiveClass3VariableIntValue( int connectionId, char* srcVarName, int srcVarLen, int destVarId );

////////////////////////////////////////////////////////////////////////////////
/*
  Use open connection to send request to read SINT values from remote srcVarName and coping the values int destVarId.
    connectionId is a connection instance as received from EtAdOpenClass3Connection
    srcVarName is a source variable name on the remote node
    srcVarLen represents number of array elements to be received, local var shall be at least of that size.
    Size of remote var (srcVarName) is not known, it want be checked.
    If srcVarLen is smaller than real size of source or destination array, only srcVarLen values will be received.
    An warn message will be logged, if during runtime there are not enough values comming from class3 connection 
  Returns 0 on success to set data table read request to the class3 connection or negative error code:
    -1: illegal connectionId
    -2: illegal destVarId
    -3: destVarId does not have enough elements (srcVarLen)
    -4: empty srcVarName
    -5: illegal srcVarLen 1..480
    -6: failed to set class3 datatable read request
*/
extern nADAPTER_API int n_EtAdReceiveClass3VariableSintValue( int connectionId, char* srcVarName, int srcVarLen, int destVarId );

////////////////////////////////////////////////////////////////////////////////
/*
  Use open connection to send request to read REAL values from remote ethernet ip controller.
    connectionId is a connection instance as received from EtAdOpenClass3Connection
    srcVarName is a source variable name on the remote node
    srcVarLen represents number of array elements to be received, local var shall be at least of that size.
    Size of remote var (srcVarName) is not known, it want be checked.
    If srcVarLen is smaller than real size of source or destination array, only srcVarLen values will be received.
    An warn message will be logged, if during runtime there are not enough values comming from class3 connection 
  Returns 0 on success or negative error code:
    -1: illegal connectionId
    -2: illegal destVarId
    -3: destVarId does not have enough elements (srcVarLen)    
    -4: empty srcVarName
    -5: illegal srcVarLen 1..120
    -6: failed to set class3 datatable read request
*/
extern nADAPTER_API int n_EtAdReceiveClass3VariableRealValue( int connectionId, char* srcVarName, int srcVarLen, int destVarId );

////////////////////////////////////////////////////////////////////////////////
/*
  Use open connection to send request to write DINT values from local variable to remote ethernet ip controller.
    connectionId is a connection instance as received from EtAdOpenClass3Connection
    destVarName is a destination variable name on the remote node
    destVarLen represents number of array elements to be written, local var shall be at least of that size.
    actual size of remote var (destVarName) is not known, it want be checked.
    If destVarLen is smaller than local variable array size, only destVarLen values will be sent.
  Returns 0 on success or negative error code:
    -1: illegal connectionId
    -2: illegal srcVarId
    -3: srcVarId does not have enough elements (destVarLen)    
    -4: empty destVarName
    -5: illegal destVarLen 1..120
    -6: failed to set class3 datatable write request
    -7: failed to read local variable values
*/
extern nADAPTER_API int n_EtAdSendClass3VariableDintValue( int connectionId, char* destVarName, int destVarLen, int srcVarId );

////////////////////////////////////////////////////////////////////////////////
/*
  Use open connection to send request to write INT values from local variable to remote ethernet ip controller.
    connectionId is a connection instance as received from EtAdOpenClass3Connection
    destVarName is a destination variable name on the remote node
    destVarLen represents number of array elements to be written, local var shall be at least of that size.
    actual size of remote var (destVarName) is not known, it want be checked.
    If destVarLen is smaller than local variable array size, only destVarLen values will be sent.
  Returns 0 on success or negative error code:
    -1: illegal connectionId
    -2: illegal srcVarId
    -3: srcVarId does not have enough elements (destVarLen)    
    -4: empty destVarName
    -5: illegal destVarLen 1..240
    -6: failed to set class3 datatable write request
    -7: failed to read local variable values
*/
extern nADAPTER_API int n_EtAdSendClass3VariableIntValue( int connectionId, char* destVarName, int destVarLen, int srcVarId );

////////////////////////////////////////////////////////////////////////////////
/*
  Use open connection to send request to write SINT values from local variable to remote ethernet ip controller.
    connectionId is a connection instance as received from EtAdOpenClass3Connection
    destVarName is a destination variable name on the remote node
    destVarLen represents number of array elements to be written, local var shall be at least of that size.
    actual size of remote var (destVarName) is not known, it want be checked.
    If destVarLen is smaller than local variable array size, only destVarLen values will be sent.
  Returns 0 on success or negative error code:
    -1: illegal connectionId
    -2: illegal srcVarId
    -3: srcVarId does not have enough elements (destVarLen)    
    -4: empty destVarName
    -5: illegal destVarLen 1..480
    -6: failed to set class3 datatable write request
    -7: failed to read local variable values
*/
extern nADAPTER_API int n_EtAdSendClass3VariableSintValue(int connectionId, char* destVarName, int destVarLen, int srcVarId );

////////////////////////////////////////////////////////////////////////////////
/*
  Use open connection to send request to write REAL values from local variable to remote ethernet ip controller.
    connectionId is a connection instance as received from EtAdOpenClass3Connection
    destVarName is a destination variable name on the remote node
    destVarLen represents number of array elements to be written, local var shall be at least of that size.
    actual size of remote var (destVarName) is not known, it want be checked.
    If destVarLen is smaller than local variable array size, only destVarLen values will be sent.
  Returns 0 on success or negative error code:
    -1: illegal connectionId
    -2: illegal srcVarId
    -3: srcVarId does not have enough elements (destVarLen)    
    -4: empty destVarName
    -5: illegal destVarLen 1..120
    -6: failed to set class3 datatable write request
    -7: failed to read local variable values
*/
extern nADAPTER_API int n_EtAdSendClass3VariableRealValue( int connectionId, char* destVarName, int destVarLen, int srcVarId );

////////////////////////////////////////////////////////////////////////////////
/*
  Sends Forward Close requests.
    connectionId is a connection instance as received from EtAdOpenClass3Connection
  Returns TRUE if the connection is closed, or negative error code:
    -1: illegal connectionId
    -2: failed to close
*/
extern nADAPTER_API BOOL n_EtAdCloseConnection( int connectionId );

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//2008년 2월 27일 추가																								  //
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/* Write given DINT values into variable elements starting from given index. Returns number of actually written elements.
 * If variable is produced values are copied into local buffer, and Class1 connection based on their transport types 
 * transmits data to all consumers.
 * NOTE: Writing to a local consumed variable will fail.
 */
extern  __declspec(dllexport) int n_EtAdPartialDintVariableWrite(int variableId, int index, INT32 *pv, int pl);

/* Write given INT values into variable elements starting from given index. Returns number of actually written elements.
 * If variable is produced values are copied into local buffer, and Class1 connection based on their transport types 
 * transmits data to all consumers.
 * NOTE: Writing to a local consumed variable will fail.
 */
extern  __declspec(dllexport) int n_EtAdPartialIntVariableWrite(int variableId, int index, INT16 *pv, int pl);

/* Write given SINT values into variable elements starting from given index. Returns number of actually written elements.
 * If variable is produced values are copied into local buffer, and Class1 connection based on their transport types 
 * transmits data to all consumers.
 * NOTE: Writing to a local consumed variable will fail.
 */
extern  __declspec(dllexport) int n_EtAdPartialSintVariableWrite(int variableId, int index, INT8 *pv, int pl);

/* Write given BOOL values into variable elements starting from given index. Returns number of actually written elements.
 * If variable is produced values are copied into local buffer, and Class1 connection based on their transport types 
 * transmits data to all consumers.
 * NOTE: Writing to a local consumed variable will fail.
 */
//extern  __declspec(dllexport) int n_EtAdPartialBoolVariableWrite(int variableId, int index, BOOL *pv, int pl);

/* Write given REAL values into variable elements starting from given index. Returns number of actually written elements.
 * If variable is produced values are copied into local buffer, and Class1 connection based on their transport types 
 * transmits data to all consumers.
 * NOTE: Writing to a local consumed variable will fail.
 */
extern  __declspec(dllexport) int n_EtAdPartialRealVariableWrite(int variableId, int index, float *pv, int pl);

/*
  Populates connection ids of active connections into provided buffer (buf,maxBufSize) and its actual size into size.
*/
extern  __declspec(dllexport) void n_EtAdGetConnectionIds(int maxBufSize, int *buf, int *size);

/*
  Gets connection info for a specified connectioId.
  Returns TRUE if there is active connection with connectionId and in that case sets all out arguments:
    type             connection type
    localVarId       local variable id, valid for class1 connections only
    transportType    transport type (cyclic,cos,)
    otherIPAddr      IP Address of the other side of the connection
    multicatsIPAddr  multicast IP adrress, valid for class1 multicast produced/consumed connections
    rate             rate in miliseconds between packets
    uptime           time in seconds since the connection is established
*/
extern  __declspec(dllexport) BOOL n_EtAdGetConnectionInfo(int connectionId, ConnectionType *type, int *localVarId, int *transportType, 
                                              UINT32 *receiveIPAddr, UINT32 *transmitIPAddr, int *rate, long *uptime);



