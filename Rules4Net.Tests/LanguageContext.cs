using System;
using System.Globalization;
using System.Threading;

namespace Rules4Net.Tests {
    public class LanguageContext : IDisposable {
        private CultureInfo oldCulture;
        private CultureInfo oldUICulture;


        public LanguageContext(CultureInfo culture) {
            this.oldCulture = Thread.CurrentThread.CurrentCulture;
            this.oldUICulture = Thread.CurrentThread.CurrentUICulture;

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
        public void Dispose() {
            Thread.CurrentThread.CurrentCulture = oldCulture;
            Thread.CurrentThread.CurrentUICulture = oldUICulture;
        }
    } //class
}
