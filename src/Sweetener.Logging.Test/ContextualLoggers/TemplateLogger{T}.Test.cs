﻿using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sweetener.Logging.Test
{
    [TestClass]
    public class ContextualTemplateLoggerTest
    {
        [TestMethod]
        public void Constructor()
        {
            // Argument Validation
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new MemoryTemplateLogger<ushort>((LogLevel)27                    ));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new MemoryTemplateLogger<ushort>((LogLevel)27  , null            ));
            Assert.ThrowsException<ArgumentNullException      >(() => new MemoryTemplateLogger<ushort>(LogLevel.Trace, null, null      ));
            Assert.ThrowsException<FormatException            >(() => new MemoryTemplateLogger<ushort>(LogLevel.Trace, null, "{foobar}"));

            // Constructor Overloads
            using (TemplateLogger<byte> logger = new MemoryTemplateLogger<byte>())
            {
                Assert.AreEqual(LogLevel.Trace                      , logger.MinLevel            );
                Assert.AreEqual(CultureInfo.CurrentCulture          , logger.FormatProvider      );
                Assert.AreEqual(TemplateLogger<byte>.DefaultTemplate, logger._template.ToString());
            }

            using (TemplateLogger<string> logger = new MemoryTemplateLogger<string>(LogLevel.Warn))
            {
                Assert.AreEqual(LogLevel.Warn                         , logger.MinLevel            );
                Assert.AreEqual(CultureInfo.CurrentCulture            , logger.FormatProvider      );
                Assert.AreEqual(TemplateLogger<string>.DefaultTemplate, logger._template.ToString());
            }

            using (TemplateLogger<Guid> logger = new MemoryTemplateLogger<Guid>(LogLevel.Info, "<{pn}|{pid}> - {msg} {cxt}"))
            {
                Assert.AreEqual(LogLevel.Info               , logger.MinLevel            );
                Assert.AreEqual(CultureInfo.CurrentCulture  , logger.FormatProvider      );
                Assert.AreEqual("<{pn}|{pid}> - {msg} {cxt}", logger._template.ToString());
            }

            CultureInfo esES = CultureInfo.GetCultureInfo("es-ES");
            using (TemplateLogger<TimeSpan> logger = new MemoryTemplateLogger<TimeSpan>(LogLevel.Error, esES, "[{tid}] {cxt} {msg}"))
            {
                Assert.AreEqual(LogLevel.Error       , logger.MinLevel            );
                Assert.AreEqual(esES                 , logger.FormatProvider      );
                Assert.AreEqual("[{tid}] {cxt} {msg}", logger._template.ToString());
            }
        }

        [TestMethod]
        public void IsSynchronized()
        {
            Assert.IsFalse(new MemoryTemplateLogger<int>(                                                           ).IsSynchronized);
            Assert.IsFalse(new MemoryTemplateLogger<int>(LogLevel.Info                                              ).IsSynchronized);
            Assert.IsFalse(new MemoryTemplateLogger<int>(LogLevel.Warn, "{cxt} {msg}"                               ).IsSynchronized);
            Assert.IsFalse(new MemoryTemplateLogger<int>(LogLevel.Debug, CultureInfo.InvariantCulture, "{cxt} {msg}").IsSynchronized);
        }

        [TestMethod]
        public void Log()
        {
            // Validate Log calls WriteLine appropriately based on the template
            // Logger{T}.Test.cs already validates that Log is called appropriately
            using (MemoryTemplateLogger<char> logger = new MemoryTemplateLogger<char>(default, CultureInfo.InvariantCulture, "{l:F} - {cxt} {msg}"))
            {
                // Trace
                logger.Trace('0', "1"                                   );
                logger.Trace('0', "1 {0}"                , 2            );
                logger.Trace('0', "1 {0} {1}"            , 2, 3         );
                logger.Trace('0', "1 {0} {1} {2}"        , 2, 3, 4      );
                logger.Trace('0', "1 {0} {1} {2} {3}"    , 2, 3, 4, 5   );
                logger.Trace('0', "1 {0} {1} {2} {3} {4}", 2, 3, 4, 5, 6);

                // Debug
                logger.Debug('0', "1"                                   );
                logger.Debug('0', "1 {0}"                , 2            );
                logger.Debug('0', "1 {0} {1}"            , 2, 3         );
                logger.Debug('0', "1 {0} {1} {2}"        , 2, 3, 4      );
                logger.Debug('0', "1 {0} {1} {2} {3}"    , 2, 3, 4, 5   );
                logger.Debug('0', "1 {0} {1} {2} {3} {4}", 2, 3, 4, 5, 6);

                // Info
                logger.Info('0', "1"                                   );
                logger.Info('0', "1 {0}"                , 2            );
                logger.Info('0', "1 {0} {1}"            , 2, 3         );
                logger.Info('0', "1 {0} {1} {2}"        , 2, 3, 4      );
                logger.Info('0', "1 {0} {1} {2} {3}"    , 2, 3, 4, 5   );
                logger.Info('0', "1 {0} {1} {2} {3} {4}", 2, 3, 4, 5, 6);

                // Warn
                logger.Warn('0', "1"                                   );
                logger.Warn('0', "1 {0}"                , 2            );
                logger.Warn('0', "1 {0} {1}"            , 2, 3         );
                logger.Warn('0', "1 {0} {1} {2}"        , 2, 3, 4      );
                logger.Warn('0', "1 {0} {1} {2} {3}"    , 2, 3, 4, 5   );
                logger.Warn('0', "1 {0} {1} {2} {3} {4}", 2, 3, 4, 5, 6);

                // Error
                logger.Error('0', "1"                                   );
                logger.Error('0', "1 {0}"                , 2            );
                logger.Error('0', "1 {0} {1}"            , 2, 3         );
                logger.Error('0', "1 {0} {1} {2}"        , 2, 3, 4      );
                logger.Error('0', "1 {0} {1} {2} {3}"    , 2, 3, 4, 5   );
                logger.Error('0', "1 {0} {1} {2} {3} {4}", 2, 3, 4, 5, 6);

                // Fatal
                logger.Fatal('0', "1"                                   );
                logger.Fatal('0', "1 {0}"                , 2            );
                logger.Fatal('0', "1 {0} {1}"            , 2, 3         );
                logger.Fatal('0', "1 {0} {1} {2}"        , 2, 3, 4      );
                logger.Fatal('0', "1 {0} {1} {2} {3}"    , 2, 3, 4, 5   );
                logger.Fatal('0', "1 {0} {1} {2} {3} {4}", 2, 3, 4, 5, 6);

                Assert.AreEqual(36, logger.Entries.Count);
                for (LogLevel level = LogLevel.Trace; logger.Entries.Count > 0; level++)
                {
                    Assert.IsTrue(logger.Entries.Count >= 6);
                    Assert.AreEqual($"{level:F} - 0 1"          , logger.Entries.Dequeue());
                    Assert.AreEqual($"{level:F} - 0 1 2"        , logger.Entries.Dequeue());
                    Assert.AreEqual($"{level:F} - 0 1 2 3"      , logger.Entries.Dequeue());
                    Assert.AreEqual($"{level:F} - 0 1 2 3 4"    , logger.Entries.Dequeue());
                    Assert.AreEqual($"{level:F} - 0 1 2 3 4 5"  , logger.Entries.Dequeue());
                    Assert.AreEqual($"{level:F} - 0 1 2 3 4 5 6", logger.Entries.Dequeue());
                }
            }
        }
    }
}
