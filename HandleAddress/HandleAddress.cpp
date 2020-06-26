#include "pch.h"

#include "HandleAddress.h"
#include<iostream>
#include <tchar.h>

namespace HandleAddress {

	public ref class AddressHelper {
		char* a;
	public:
		const char* __stdcall add1;
		const char* __stdcall add2;
		const char* __stdcall add3;
		const char* __stdcall add4;
		const char* __stdcall add5;
	public:
		/*
		static MyStruct test(char* a) {
			string all = a;
			vector<string> separate = {};
			string::size_type pos1, pos2;
			string c = "%";
			pos2 = all.find(c);
			pos1 = 0;
			while (string::npos != pos2)
			{
				separate.push_back(all.substr(pos1, pos2 - pos1));
				pos1 = pos2 + c.size();
				pos2 = all.find(c, pos1);

			}
			if (pos1 != all.length()) {
				separate.push_back(all.substr(pos1));
			}

			MyStruct myStruct;
			for (int i = 0; i < separate.size(); i++) {
				char temp[100];
				int j = 0;
				for (j; j < separate[i].length(); j++) {
					temp[j] = separate[i][j];
				}
				temp[j] = '\0';
				if (i == 0) {
					myStruct.add1 = temp;
				}
				else if (i == 1) {
					myStruct.add2 = temp;
				}
				else if (i == 2) {
					myStruct.add2 = temp;
				}
				else if (i == 3) {
					myStruct.add2 = temp;
				}
				else if (i == 4) {
					myStruct.add2 = temp;
				}
				else {
					break;
				}
			}
			
			return myStruct;
		}*/
		AddressHelper(char* __stdcall all) {
			this->a = all;
		}

		void test() {
			string all = this->a;
			vector<string> separate = {};
			string::size_type pos1, pos2;
			string c = "%";
			pos2 = all.find(c);
			pos1 = 0;
			while (string::npos != pos2)
			{
				separate.push_back(all.substr(pos1, pos2 - pos1));
				pos1 = pos2 + c.size();
				pos2 = all.find(c, pos1);

			}
			if (pos1 != all.length()) {
				separate.push_back(all.substr(pos1));
			}

			for (int i = 0; i < separate.size(); i++) {
				string tempStr = separate[i];

				if (i == 0) {
					this->add1 = tempStr.c_str();
				}
				else if (i == 1) {
					this->add2 = tempStr.c_str();
				}
				else if (i == 2) {
					this->add3 = tempStr.c_str();
				}
				else if (i == 3) {
					this->add4 = tempStr.c_str();
				}
				else if (i == 4) {
					this->add5 = tempStr.c_str();
				}
				else {
					break;
				}
			}

			return;
		}
	};
}