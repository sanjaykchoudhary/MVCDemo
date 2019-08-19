using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.ObjectModel;

namespace IterationDemoCS
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating a StringCollection named myCol.
            StringCollection myCol = new StringCollection();
            
            myCol.Add("A");
            myCol.Add("B");
            myCol.Add("C");
            myCol.Add("D");
            myCol.Add("E");
            myCol.Add("F");
            //Taking an enumerator and using GetEnumerator method.
            //Supports a simple iteration over a StringCollection.
            StringEnumerator myEnumeration = myCol.GetEnumerator();
            //If MoveNext passes the end of the collection, the enumerator is positioned
            //after the last element in the collection and MoveNext returns false.
            while(myEnumeration.MoveNext())
            {
                Console.WriteLine(myEnumeration.Current);
            }

            //StringDictionary collection enumeration.
            StringDictionary dict = new StringDictionary();
            dict.Add("A", "ABC");
            dict.Add("B", "AEC");
            dict.Add("C", "AVC");
            dict.Add("D", "ADC");
            dict.Add("E", "ARC");
            //IEnumerator interface supports a simple iteration over a non-generic collection.
            IEnumerator enumerator = dict.GetEnumerator();
            //Defines dictionary key/value pair that can be set or retrieved.
            DictionaryEntry dictEntry;
            while(enumerator.MoveNext())
            {
                dictEntry = (DictionaryEntry)enumerator.Current;
                Console.WriteLine(dictEntry.Key + ":" + dictEntry.Value);
            }

            //Creating a Hybrid dictionary 
            HybridDictionary myHybridDict = new HybridDictionary();
            //Adding key/value pairs in hybrid dictionary.
            myHybridDict.Add("I", "first");
            myHybridDict.Add("II", "second");
            myHybridDict.Add("III", "third");
            myHybridDict.Add("IV", "fourth");
            myHybridDict.Add("V", "fifth");
            //To get an IDictionary enumerator for the hybrid dictionary.
            IDictionaryEnumerator iDictEnum = myHybridDict.GetEnumerator();
            while(iDictEnum.MoveNext())
            {
                Console.WriteLine(iDictEnum.Key + "-->" + iDictEnum.Value);
            }

            //Creating a HashTable.
            Hashtable myHash = new Hashtable();
            //Adding key/value pair for hash table.
            myHash.Add("A", "Apple");
            myHash.Add("B", "Banana");
            myHash.Add("C", "Custard Apple");
            myHash.Add("D", "Dry fruits");
            myHash.Add("E", "Eagle");

            //To get an IDictionaryEnumerator for Hashtable.
            IDictionaryEnumerator iDictHash = myHash.GetEnumerator();
            while(iDictHash.MoveNext())
            {
                Console.WriteLine(iDictHash.Key + "-->" + iDictHash.Value);
            }

            //Creating a ListDictionary 
            ListDictionary myLstDict = new ListDictionary();
            myLstDict.Add("India", "New Delhi");
            myLstDict.Add("Australia", "Canberra");
            myLstDict.Add("Belgium", "Brussels");
            myLstDict.Add("Netherland", "Amsterdam");
            myLstDict.Add("China", "Beijing");
            myLstDict.Add("Russia", "Moscow");
            //To get an IDictionaryEnumerator for the ListDictionary.
            IDictionaryEnumerator iDictEnumLstDict = myLstDict.GetEnumerator();
            while(iDictEnumLstDict.MoveNext())
            {
                Console.WriteLine(iDictEnumLstDict.Key + "-->" + iDictEnumLstDict.Value);
            }
            //Creating a SortedDictionary.
            SortedDictionary<string, string> mySortedDict = new SortedDictionary<string, string>();
            mySortedDict.Add("India", "New Delhi");
            mySortedDict.Add("Australia", "Canberra");
            mySortedDict.Add("Belgium", "Brussels");
            mySortedDict.Add("Netherland", "Amsterdam");
            mySortedDict.Add("China", "Beijing");
            mySortedDict.Add("Russia", "Moscow");
            //To get an IDictionaryEnumerator for the SortedDictionary.
            IDictionaryEnumerator iDictEnumerator = mySortedDict.GetEnumerator();
            while(iDictEnumerator.MoveNext())
            {
                Console.WriteLine(iDictEnumerator.Key + "-->" + iDictEnumerator.Value);
            }
            //Creating a collection of string.
            Collection<string> myColl = new Collection<string>();
            myColl.Add("ABD");
            myColl.Add("DEF");
            myColl.Add("CFR");
            myColl.Add("EVF");
            myColl.Add("NBR");
            IEnumerator<string> enumColl = myColl.GetEnumerator();
            while(enumColl.MoveNext())
            {
                Console.WriteLine(enumColl.Current);
            }

            //Creating a Linked list of integers.
            LinkedList<int> myLinkedList = new LinkedList<int>();
            myLinkedList.AddLast(2);
            myLinkedList.AddLast(21);
            myLinkedList.AddLast(12);
            myLinkedList.AddLast(23);
            myLinkedList.AddLast(32);
            //To get an enumerator for the List.
            LinkedList<int>.Enumerator lnkListEnum = myLinkedList.GetEnumerator();
            Display(lnkListEnum);

            //Creating a Hashset<T> of strings.
            //Initialize a new instance of HashSet<string> class that is empty 
            //and uses the default equality comparer for the set type.
            HashSet<string> hashset = new HashSet<string>();
            hashset.Add("C#");
            hashset.Add("Asp.Net");
            hashset.Add("SQL Server");
            hashset.Add("MVC");
            hashset.Add("Angular");
            //To get an enumerator for the HashSet<T>.
            HashSet<string>.Enumerator hashEnum = hashset.GetEnumerator();
            DisplayHashSet(hashEnum);
            Console.ReadKey();
        }

        static void DisplayHashSet(IEnumerator<string> en)
        {
            while(en.MoveNext())
            {
                Console.WriteLine(en.Current);
            }
        }

        static void Display(IEnumerator<int> en)
        {
            while(en.MoveNext())
            {
                Console.WriteLine(en.Current);
            }
        }
    }
}
