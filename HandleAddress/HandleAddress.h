#pragma once
#include<stdio.h>
#include<vector>
#include <string>
using namespace System;
using namespace std;

namespace HandleAddress {
	public class Handler
	{
	public:
		string all;
		vector<string> separate;
		Handler() {
			all = "";
			separate = {};
		}
		Handler(string allAdd) {
			all = allAdd;
			separate = {};
		}
		Handler(vector<string> separateAdd) {
			all = "";
			separate = separateAdd;
		}
		string getAll() {
			return all;
		}

		vector<string> getSeparate() {
			return separate;
		}
		int separateAdd() {
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

			return separate.size();
		}
		void concatenate() {
			all = separate[0];
			for (int i = 1; i < separate.size(); i++) {
				all += separate[i];
			}
		}
		// TODO: 在此处为此类添加方法。
	};
	public ref class AddressHandler
	{
	public:
		Handler* handler;

		AddressHandler() {
			handler = new Handler();
		}

		AddressHandler(string allAdd) {
			handler = new Handler(allAdd);
		}

		AddressHandler(vector<string> separateAdd) {
			handler = new Handler(separateAdd);
		}

		string getAll() {
			return handler->getAll();
		}

		vector<string> getSeparate() {
			return handler->getSeparate();
		}

		int separate() {
			return handler->separateAdd();
		}

		void concatenate() {
			handler->concatenate();
		}
	};
}
