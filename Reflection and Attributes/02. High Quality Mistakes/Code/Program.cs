using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Stealer;

class Program {
    public static void Main() {
        Spy spy = new Spy();
        string result = spy.AnalyzeAccessModifiers("Stealer.Hacker");
        Console.WriteLine(result);       
    }
}








