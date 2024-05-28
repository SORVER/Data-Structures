#include <iostream>
#define ll long long
using namespace std;

#include <bits/stdc++.h>

class trieNode{
    public:
    map<char,trieNode*> children;
    int End  ;
    int prefix = 0;

    trieNode(){
        End = prefix =0;
    }
      
};
class Trie {  
    private:
    trieNode* root;
    public:
    Trie()
    {
    root = new trieNode();
    }
    
    void insert(string ss){
            trieNode* rootHere = root;
            for(auto ch : ss){
                      if(rootHere->children.find(ch) == rootHere->children.end()){
                            rootHere->children[ch] = new trieNode();
                      }

                      rootHere = rootHere->children[ch];
                       rootHere->prefix++;
            }

            rootHere->End++;
    }


    int count(string ss){
            trieNode* rootHere = root;
            for(auto ch : ss){
                      if(rootHere->children.find(ch) == rootHere->children.end()){
                            return 0;
                      }

                      rootHere = rootHere->children[ch];
            }

            return rootHere->End;
    }

};

int main() {
   
    Trie trie;


    trie.insert("mahmoud");

    cout<< trie.count("mahmoud");




}
