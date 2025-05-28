#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFBenchmark.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     The abstract class GDFBenchmark provides methods for benchmarking performance.
    /// </summary>
    public abstract class GDFBenchmark
    {
        #region Static fields and properties

        /// <summary>
        ///     Represents a benchmarking utility for measuring the performance of code.
        /// </summary>
        private static Dictionary<string, long> cQuickStartDico = new Dictionary<string, long>();

        /// <summary>
        ///     A class that provides benchmarking functionality.
        /// </summary>
        private static Dictionary<string, long> cStartDico = new Dictionary<string, long>();

        /// <summary>
        ///     A dictionary that stores the start and step durations of benchmarks.
        /// </summary>
        private static Dictionary<string, long> cStepDico = new Dictionary<string, long>();

        /// <summary>
        ///     Represents the result data of the benchmark for individual methods.
        /// </summary>
        private static Dictionary<string, List<double>> kMethodResult = new Dictionary<string, List<double>>();

        /// <summary>
        ///     Class for managing benchmarking operations.
        /// </summary>
        private static GDFBenchmarkParameters Parameter = new GDFBenchmarkParameters();

        /// <summary>
        ///     Represents a benchmark utility for measuring performance in code.
        /// </summary>
        private static int StartCount = 0;

        /// <summary>
        ///     This class provides methods for benchmarking code execution time.
        /// </summary>
        private static Stopwatch Watch = new Stopwatch();

        #endregion

        #region Static constructors and destructors

        /// GDFBenchmark is a class that provides benchmarking functionality for measuring the performance of code execution.
        /// /
        static GDFBenchmark()
        {
            Watch.Start();
        }

        #endregion

        #region Static methods

        /// <summary>
        ///     Retrieves and displays all benchmark results, if enabled.
        /// </summary>
        /// <remarks>
        ///     This method retrieves and displays all benchmark results,
        ///     if the benchmark parameters are enabled.
        /// </remarks>
        public static void AllResults()
        {
            if (Parameter != null)
            {
                if (Parameter.IsEnable == true)
                {
                    foreach (KeyValuePair<string, List<double>> tResult in kMethodResult)
                    {
                        List<double> tResultList = tResult.Value.OrderByDescending(d => d).ToList();
                        double rRawDelta = Enumerable.Average(tResultList);
                        double rRawSum = Enumerable.Sum(tResultList);
                        double rRawMax = Enumerable.Max(tResultList);
                        double rRawMin = Enumerable.Min(tResultList);
                        double rDelta = rRawDelta;
                        double rMax = rRawMax;
                        double rMin = rRawMin;
                        bool AA = false;
                        int tD = 0;
                        if (tResultList.Count > 20)
                        {
                            AA = true;
                            int tCount = tResultList.Count;
                            int tNN = (int)Math.Floor(tCount * 0.95);
                            tD = tCount - tNN;
                            for (int i = 0; i < tD; i++)
                            {
                                //tResultList.RemoveAt(tResultList.Count-1);
                                tResultList.RemoveAt(0);
                            }

                            rMax = Enumerable.Max(tResultList);
                            rMin = Enumerable.Min(tResultList);
                        }

                        rDelta = Enumerable.Average(tResultList);
                        string tMaxColor = Parameter.Green;
                        if (rDelta >= Parameter.kWarningDefault)
                        {
                            tMaxColor = Parameter.Orange;
                        }

                        if (rDelta >= Parameter.kMaxDefault)
                        {
                            tMaxColor = Parameter.Red;
                        }

                        string tSumColor = Parameter.Green;
                        if (rRawSum >= Parameter.kWarningDefault)
                        {
                            tSumColor = Parameter.Orange;
                        }

                        if (rRawSum >= Parameter.kMaxDefault)
                        {
                            tSumColor = Parameter.Red;
                        }

                        GDFLogger.Trace("benchmark Result " +
                                        "'<b>" + tResult.Key + "</b>' has " + tResultList.Count + " value" + (tResult.Value.Count > 1 ? "s" : "") +
                                        " and average is <color=" + tMaxColor + ">" + rDelta.ToString("F6") + "</color> seconds" +
                                        (tResult.Value.Count > 1 ? " (min " + rMin.ToString("F6") + " max " + rMax.ToString("F6") + ")" : "") +
                                        (AA == true ? " at 95%  with " + tResult.Value.Count + " raw datas average <color=" + tMaxColor + ">" + rRawDelta.ToString("F6") + "</color> seconds (min " + rRawMin.ToString("F6") + " max " + rRawMax.ToString("F6") + ") " : " ") +
                                        (tResult.Value.Count > 1 ? " sum is <color=" + tSumColor + ">" + rRawSum.ToString("F6") + "</color> seconds" : "") +
                                        ""
                        );
                    }
                }
            }
        }

        /// <summary>
        ///     Finishes the benchmark for a specific key with optional debug information.
        /// </summary>
        /// <param name="sWithDebug">Determines whether to include debug information in the benchmark result.</param>
        /// <param name="sMoreInfos">Additional information to be included in the benchmark result.</param>
        public static void Finish(bool sWithDebug = true, string sMoreInfos = "")
        {
            if (Parameter != null)
            {
                if (Parameter.IsEnable == true)
                {
                    Finish(GetKey(), sWithDebug, sMoreInfos);
                }
            }
        }

        /// <summary>
        ///     Finishes a benchmark step and logs the elapsed time.
        /// </summary>
        /// <param name="sKey"></param>
        /// <param name="sWithDebug">Whether to log the debugging information or not. Default is true.</param>
        /// <param name="sMoreInfos">Additional information to log along with the elapsed time. Default is an empty string.</param>
        public static void Finish(string sKey, bool sWithDebug = true, string sMoreInfos = "")
        {
            if (Parameter != null)
            {
                if (Parameter.IsEnable == true)
                {
                    if (cStepDico.ContainsKey(sKey) == true)
                    {
                        cStepDico[sKey] = Watch.ElapsedMilliseconds;
                    }
                    else
                    {
                        cStepDico.Add(sKey, Watch.ElapsedMilliseconds);
                    }

                    double rDelta = 0;
                    double rFrameSpend = 0;
                    if (cStartDico.ContainsKey(sKey) == true)
                    {
                        rDelta = (Watch.ElapsedMilliseconds - cStartDico[sKey]) / 1000.0F;
                        rFrameSpend = Parameter.FrameRate * rDelta;
                        string tMaxColor = Parameter.Green;
                        if (rDelta >= Parameter.kWarningDefault)
                        {
                            tMaxColor = Parameter.Orange;
                        }

                        if (rDelta >= Parameter.kMaxDefault)
                        {
                            tMaxColor = Parameter.Red;
                        }

                        if (rDelta > Parameter.BenchmarkLimit)
                        {
                            if (Parameter.BenchmarkShowStart == true)
                            {
                                GDFLogger.Trace("benchmark : " + GetIndentation() + "| <b><color=" + tMaxColor + ">" + rDelta.ToString("F3") + "</color></b>" + "");
                            }

                            string tLog = "benchmark : " + GetIndentation() + "•<b>" + sKey + "</b>\t" + " execute in <color=" + tMaxColor + ">" +
                                          rDelta.ToString("F3") + " seconds </color> spent " + rFrameSpend.ToString("F1") + "F/" + Parameter.FrameRate + "Fps. " + sMoreInfos;
                            GDFLogger.Trace(tLog);
                        }

                        StartCount--;
                        cStartDico.Remove(sKey);

                        if (kMethodResult.ContainsKey(sKey) == false)
                        {
                            kMethodResult.Add(sKey, new List<double>());
                        }

                        kMethodResult[sKey].Add(rDelta);
                    }
                    else
                    {
                        GDFLogger.Error("benchmark : error '" + GetIndentation() + sKey + "' has no start value. " + sMoreInfos);
                    }
                }
            }
        }

        /// <summary>
        ///     Returns the string representation of the indentation used in the benchmark logging.
        /// </summary>
        /// <returns>The indentation string.</returns>
        private static string GetIndentation()
        {
            string rReturn = "";
            for (int i = 0; i < StartCount; i++)
            {
                if (i == 0)
                {
                    rReturn = rReturn + "\t";
                }
                else
                {
                    rReturn = rReturn + "|\t";
                }
            }

            return rReturn;
        }

        /// <summary>
        ///     Returns the key representing the calling method.
        /// </summary>
        /// <returns>The key representing the calling method.</returns>
        private static string GetKey()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(2);
            MethodBase tM = sf.GetMethod();
            string tDot = ".";
            if (tM.IsStatic == true)
            {
                tDot = ">";
            }

            string tMethod = tM.DeclaringType.Name + tDot + tM.Name;
            return tMethod;
        }

        /// <summary>
        ///     Gets the benchmark parameters.
        /// </summary>
        /// <returns>The benchmark parameters.</returns>
        public static GDFBenchmarkParameters GetParameters()
        {
            if (Parameter == null)
            {
                Parameter = new GDFBenchmarkParameters();
            }

            return Parameter;
        }

        /// <summary>
        ///     Writes a log message.
        /// </summary>
        /// <param name="sInfos">The log message.</param>
        public static void Log(string sInfos = "")
        {
            if (Parameter != null)
            {
                if (Parameter.IsEnable == true)
                {
                    GDFLogger.Trace("benchmark : " + GetIndentation() + "|\t• " + " Log : " + sInfos);
                }
            }
        }

        /// <summary>
        ///     Logs a warning message to the console.
        /// </summary>
        /// <param name="sInfos">Additional information to be included in the log message.</param>
        public static void LogWarning(string sInfos = "")
        {
            if (Parameter != null)
            {
                if (Parameter.IsEnable == true)
                {
                    GDFLogger.Warning("benchmark : " + GetIndentation() + "|\t !!! " + " Log : " + sInfos);
                }
            }
        }

        /// <summary>
        ///     Represents a benchmarking utility for measuring code execution time.
        /// </summary>
        public static void PrefReload()
        {
            if (Parameter != null)
            {
                Parameter.PrefReload();
            }
        }

        /// <summary>
        ///     Finishes the quick benchmark measurement for the given key.
        /// </summary>
        /// <param name="sKey">The key for which the quick benchmark measurement is being finished. If not specified, the current key will be used.</param>
        public static void QuickFinish(string sKey = null)
        {
            if (Parameter != null)
            {
                if (Parameter.IsEnable == true)
                {
                    string tKey = string.Empty;
                    if (sKey != null)
                    {
                        tKey = GetKey();
                        tKey = tKey + " <color=" + Parameter.Blue + ">" + sKey + "</color>";
                    }
                    else
                    {
                        tKey = GetKey();
                    }

                    if (cQuickStartDico.ContainsKey(tKey) == true)
                    {
                        double rDelta = (Watch.ElapsedMilliseconds - cQuickStartDico[tKey]) / 1000.0F;
                        cQuickStartDico.Remove(tKey);
                        if (kMethodResult.ContainsKey(tKey) == false)
                        {
                            kMethodResult.Add(tKey, new List<double>());
                        }

                        kMethodResult[tKey].Add(rDelta);
                    }
                    else
                    {
                        GDFLogger.Error("benchmark : error '" + tKey + "' has no QuickStart value.");
                    }
                }
            }
        }

        /// <summary>
        ///     Starts a benchmark if enabled and adds it to the QuickStart dictionary.
        /// </summary>
        /// <param name="sKey">The key for the benchmark. If provided, it will be appended to the generated key.</param>
        public static void QuickStart(string sKey = null)
        {
            if (Parameter != null)
            {
                if (Parameter.IsEnable == true)
                {
                    string tKey = string.Empty;
                    if (sKey != null)
                    {
                        tKey = GetKey();
                        tKey = tKey + " <color=" + Parameter.Blue + ">" + sKey + "</color>";
                    }
                    else
                    {
                        tKey = GetKey();
                    }

                    if (cQuickStartDico.ContainsKey(tKey) == true)
                    {
                        //string tLog = "benchmark : " + GetIndentation() + "<b>" + tKey + "</b>\t" + " all ready started!";
                    }
                    else
                    {
                        cQuickStartDico.Add(tKey, Watch.ElapsedMilliseconds);
                    }
                }
            }
        }

        /// <summary>
        ///     Resets all benchmark data and restarts the stopwatch.
        /// </summary>
        public static void ResetAll()
        {
            Watch.Restart();
            cStartDico.Clear();
        }

        /// <summary>
        ///     Resets all the results of each method.
        /// </summary>
        public static void ResetAllResults()
        {
            kMethodResult = new Dictionary<string, List<double>>();
        }

        /// <summary>
        ///     Set the parameters for the GDFBenchmark.
        /// </summary>
        /// <param name="sParameter">The GDFBenchmarkParameters object containing the parameters.</param>
        public static void SetParameters(GDFBenchmarkParameters sParameter)
        {
            if (sParameter != null)
            {
                Parameter = sParameter;
            }
        }

        /// <summary>
        ///     Start the benchmark with the default key.
        /// </summary>
        public static void Start()
        {
            if (Parameter != null)
            {
                if (Parameter.IsEnable == true)
                {
                    Start(GetKey());
                }
            }
        }

        /// <summary>
        ///     Starts a benchmark session if benchmarking is enabled.
        /// </summary>
        public static void Start(string sKey)
        {
            if (Parameter != null)
            {
                if (Parameter.IsEnable == true)
                {
                    if (cStartDico.ContainsKey(sKey) == true)
                    {
                    }
                    else
                    {
                        StartCount++;
                        cStartDico.Add(sKey, Watch.ElapsedMilliseconds);
                        if (cStepDico.ContainsKey(sKey) == true)
                        {
                            cStepDico[sKey] = Watch.ElapsedMilliseconds;
                        }
                        else
                        {
                            cStepDico.Add(sKey, Watch.ElapsedMilliseconds);
                        }

                        if (Parameter.BenchmarkShowStart == true)
                        {
                            string tLog = "benchmark : " + GetIndentation() + "•<b>" + sKey + "</b>\t" + " start now!";
                            GDFLogger.Trace(tLog);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Starts a step in the benchmark process.
        /// </summary>
        /// <param name="sWithDebug">Indicates if debug information should be logged.</param>
        /// <param name="sMoreInfos">Additional information to be logged.</param>
        public static void Step(bool sWithDebug = true, string sMoreInfos = "")
        {
            if (Parameter != null)
            {
                if (Parameter.IsEnable == true)
                {
                    Step(GetKey(), sWithDebug, sMoreInfos);
                }
            }
        }

        /// <summary>
        ///     Starts a step for benchmarking.
        /// </summary>
        /// <param name="sKey"></param>
        /// <param name="sWithDebug">Whether to enable debug information for this step. Default is true.</param>
        /// <param name="sMoreInfos">Additional information about the step.</param>
        public static void Step(string sKey, bool sWithDebug = true, string sMoreInfos = "")
        {
            if (Parameter != null)
            {
                if (Parameter.IsEnable == true)
                {
                    double rDeltaAbsolute = 0;
                    double rDelta = 0;
                    double rFrameSpend = 0;
                    long LastStep = 0;
                    if (cStartDico.ContainsKey(sKey) == true)
                    {
                        rDeltaAbsolute = (Watch.ElapsedMilliseconds - cStartDico[sKey]) / 1000.0F;
                        if (cStartDico.ContainsKey(sKey) == true)
                        {
                            LastStep = cStepDico[sKey];
                        }

                        rDelta = (Watch.ElapsedMilliseconds - LastStep) / 1000.0F;
                        rFrameSpend = Parameter.FrameRate * rDelta;
                        string tMaxColor = Parameter.Green;
                        if (rDelta >= Parameter.kWarningDefault)
                        {
                            tMaxColor = Parameter.Orange;
                        }

                        if (rDelta >= Parameter.kMaxDefault)
                        {
                            tMaxColor = Parameter.Red;
                        }

                        if (rDelta > Parameter.BenchmarkLimit)
                        {
                            string tLog = "benchmark : " + GetIndentation() + "|    <b>" + sKey + "</b>\t" + " step <color=" + tMaxColor + ">" +
                                          rDelta.ToString("F3") + " seconds </color> spent " + rFrameSpend.ToString("F1") + "F/" + Parameter.FrameRate + "Fps. (Delta Absolute = " + rDeltaAbsolute.ToString("F3") + ") " + sMoreInfos;
                            GDFLogger.Trace(tLog);
                        }
                    }
                    else
                    {
                        GDFLogger.Error("benchmark : error '" + GetIndentation() + sKey + "' has no start value. " + sMoreInfos);
                    }

                    if (cStepDico.ContainsKey(sKey) == true)
                    {
                        cStepDico[sKey] = Watch.ElapsedMilliseconds;
                    }
                    else
                    {
                        cStepDico.Add(sKey, Watch.ElapsedMilliseconds);
                    }
                }
            }
        }

        /// <summary>
        ///     Provides methods for benchmarking and tracing code execution.
        /// </summary>
        public static void Trace()
        {
            if (Parameter != null)
            {
                if (Parameter.IsEnable == true)
                {
                    GDFLogger.Trace("TRACE " + GetKey());
                }
            }
        }

        #endregion
    }
}