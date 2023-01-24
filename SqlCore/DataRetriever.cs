using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SqlCore
{
	class DataRetriever
	{
		private SqlConnection connection;
		public ConnectionState State
		{
			get { return connection.State; }
		}

		public DataRetriever(string connectString)
		{
			try
			{
				if (connection != null) connection.Close();
				connection = new SqlConnection(connectString);
				connection.Open();
			}
			catch
			{
			}
		}
		public bool Disconnect()
		{
			if (connection != null) connection.Close();
			return true;
		}

		public SqlDataReader ExecuteReader(string query)
		{
			try
			{
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.CommandText = query;
					cmd.Connection = connection;

					return cmd.ExecuteReader();
				}
			}
			catch
			{
				return null;
			}
		}
		public int ExecuteNonQuery(string query)
		{
			try
			{
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.CommandText = query;
					cmd.Connection = connection;

					return cmd.ExecuteNonQuery();
				}
			}
			catch
			{
				return -1;
			}
		}
		public int BulkCopy(DataTable dataTable, string table)
		{
			try
			{
				SqlBulkCopy bulkCopy = new SqlBulkCopy(connection);
				bulkCopy.DestinationTableName = table;
				
				bulkCopy.WriteToServer(dataTable);

				return 1;
			}
			catch
			{
				return -1;
			}
		}
	}
}
