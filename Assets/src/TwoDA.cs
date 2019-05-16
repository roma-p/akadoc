using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class TwoDA : UnityEngine.Object {

	public TwoDA(string filepath) {

		// Read the file and display it line by line.
		System.IO.StreamReader file = new System.IO.StreamReader(filepath);

		string line = file.ReadLine();
		m_header = line.Split((string[])null, System.StringSplitOptions.RemoveEmptyEntries);
		int nCols = m_header.Length;

		m_data = new List<string[]>();

		int nFileLine = 1;
		while((line = file.ReadLine()) != null)
		{
			if(line[0] != '#') { //Ignore commented lines

				MatchCollection matches = m_rgxField.Matches(line);

				if(matches.Count == nCols) {
					int nLine = int.Parse(matches[0].Value);

					string[] buff = new string[nCols-1];
					for(int i=0 ; i<nCols-1 ; i++) {

						if(matches[i+1].Groups[1].Success)//Match one word
							buff[i] = matches[i+1].Groups[1].Value;
						else if(matches[i+1].Groups[2].Success)//Match multi word
							buff[i] = matches[i+1].Groups[2].Value;
					}

					m_data.Add(buff);
				}
				else
					Debug.LogWarning(filepath+": line "+nFileLine.ToString()+" ignored. Found "+matches.Count.ToString()+" columns instead of "+nCols.ToString());

			}

			nFileLine++;
		}

		file.Close();
	}

	public T GetValue<T>(int nRow, string sColumn) {

		int nCol = FindHeaderCol(sColumn);
		if(nCol>=0) {
			return (T)Convert.ChangeType(m_data[nRow][nCol], typeof(T));
		}
		else {
			throw new UnityException("Column '"+sColumn+"' not found in 2DA");
		}

	}

	public override string ToString() {
		string sMsg = "";
		foreach(string s in m_header) {
			sMsg += s+"\t";
		}
		sMsg += "\n";
		for(int line=0 ; line<m_data.Count ; line++) {
			sMsg += line.ToString() + "\t";
			for(int col=0 ; col<m_data[line].Length ; col++) {
				sMsg += m_data[line][col]+"\t";
			}
			sMsg += "\n";
		}
		return sMsg;
	}

	private int FindHeaderCol(string sColName) {
		for(int i=0 ; i<m_header.Length ; i++) {
			if(m_header[i] == sColName)
				return i-1;
		}
		return -1;
	}

	private static Regex m_rgxField = new Regex("(?:\\b([^\\s]+?)\\b|\"([^\"]+?)\")");
	private string[] m_header;
	private List<string[]> m_data;
}