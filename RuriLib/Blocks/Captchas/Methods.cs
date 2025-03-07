﻿using CaptchaSharp.Enums;
using CaptchaSharp.Models;
using RuriLib.Attributes;
using RuriLib.Logging;
using RuriLib.Models.Bots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuriLib.Blocks.Captchas
{
    [BlockCategory("Captchas", "Blocks for solving captchas", "#7df9ff")]
    public static class Methods
    {
        [Block("Solves a text captcha")]
        public static async Task<string> SolveTextCaptcha(BotData data, string question,
            CaptchaLanguageGroup languageGroup = CaptchaLanguageGroup.NotSpecified,
            CaptchaLanguage language = CaptchaLanguage.NotSpecified)
        {
            data.Logger.LogHeader();
            await CheckBalance(data);

            var response = await data.Providers.Captcha.SolveTextCaptchaAsync(question, 
                new TextCaptchaOptions
                { 
                    CaptchaLanguage = language,
                    CaptchaLanguageGroup = languageGroup 
                }, data.CancellationToken);

            AddCaptchaId(data, response.Id, CaptchaType.TextCaptcha);
            data.Logger.Log($"Got solution: {response.Response}", LogColors.ElectricBlue);
            return response.Response;
        }

        [Block("Solves an image captcha")]
        public static async Task<string> SolveImageCaptcha(BotData data, string base64,
            CaptchaLanguageGroup languageGroup = CaptchaLanguageGroup.NotSpecified,
            CaptchaLanguage language = CaptchaLanguage.NotSpecified, bool isPhrase = false, bool caseSensitive = true,
            bool requiresCalculation = false, CharacterSet characterSet = CharacterSet.NotSpecified,
            int minLength = 0, int maxLength = 0, string textInstructions = "")
        {
            data.Logger.LogHeader();
            await CheckBalance(data);

            var response = await data.Providers.Captcha.SolveImageCaptchaAsync(base64,
                new ImageCaptchaOptions
                {
                    CaptchaLanguage = language,
                    CaptchaLanguageGroup = languageGroup,
                    IsPhrase = isPhrase,
                    CaseSensitive = caseSensitive,
                    RequiresCalculation = requiresCalculation,
                    CharacterSet = characterSet,
                    MinLength = minLength,
                    MaxLength = maxLength,
                    TextInstructions = textInstructions
                }, data.CancellationToken);

            AddCaptchaId(data, response.Id, CaptchaType.ImageCaptcha);
            data.Logger.Log($"Got solution: {response.Response}", LogColors.ElectricBlue);
            return response.Response;
        }

        [Block("Solves a ReCaptcha V2")]
        public static async Task<string> SolveRecaptchaV2(BotData data, string siteKey, string siteUrl, bool isInvisible = false,
            bool useProxy = false,
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36")
        {
            data.Logger.LogHeader();
            await CheckBalance(data);

            var response = await data.Providers.Captcha.SolveRecaptchaV2Async(siteKey, siteUrl, isInvisible,
                SetupProxy(data, useProxy, userAgent), data.CancellationToken);

            AddCaptchaId(data, response.Id, CaptchaType.ReCaptchaV2);
            data.Logger.Log($"Got solution: {response.Response}", LogColors.ElectricBlue);
            return response.Response;
        }

        [Block("Solves a ReCaptcha V3")]
        public static async Task<string> SolveRecaptchaV3(BotData data, string siteKey, string siteUrl, string action,
            float minScore = 0.3F, bool useProxy = false,
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36")
        {
            data.Logger.LogHeader();
            await CheckBalance(data);

            var response = await data.Providers.Captcha.SolveRecaptchaV3Async(siteKey, siteUrl, action, minScore,
                SetupProxy(data, useProxy, userAgent), data.CancellationToken);

            AddCaptchaId(data, response.Id, CaptchaType.ReCaptchaV3);
            data.Logger.Log($"Got solution: {response.Response}", LogColors.ElectricBlue);
            return response.Response;
        }

        [Block("Solves a FunCaptcha")]
        public static async Task<string> SolveFunCaptcha(BotData data, string publicKey, string serviceUrl, string siteUrl,
            bool noJS = false, bool useProxy = false,
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36")
        {
            data.Logger.LogHeader();
            await CheckBalance(data);

            var response = await data.Providers.Captcha.SolveFuncaptchaAsync(publicKey, serviceUrl, siteUrl, noJS,
                SetupProxy(data, useProxy, userAgent), data.CancellationToken);

            AddCaptchaId(data, response.Id, CaptchaType.FunCaptcha);
            data.Logger.Log($"Got solution: {response.Response}", LogColors.ElectricBlue);
            return response.Response;
        }

        [Block("Solves a HCaptcha")]
        public static async Task<string> SolveHCaptcha(BotData data, string siteKey, string siteUrl,
            bool useProxy = false,
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36")
        {
            data.Logger.LogHeader();
            await CheckBalance(data);

            var response = await data.Providers.Captcha.SolveHCaptchaAsync(siteKey, siteUrl,
                SetupProxy(data, useProxy, userAgent), data.CancellationToken);

            AddCaptchaId(data, response.Id, CaptchaType.HCaptcha);
            data.Logger.Log($"Got solution: {response.Response}", LogColors.ElectricBlue);
            return response.Response;
        }

        [Block("Solves a Capy captcha")]
        public static async Task<string> SolveCapyCaptcha(BotData data, string siteKey, string siteUrl,
            bool useProxy = false,
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36")
        {
            data.Logger.LogHeader();
            await CheckBalance(data);

            var response = await data.Providers.Captcha.SolveCapyAsync(siteKey, siteUrl,
                SetupProxy(data, useProxy, userAgent), data.CancellationToken);

            AddCaptchaId(data, response.Id, CaptchaType.Capy);
            data.Logger.Log($"Got solution: {response.Response}", LogColors.ElectricBlue);
            return response.Response;
        }

        [Block("Solves a KeyCaptcha")]
        public static async Task<string> SolveKeyCaptcha(BotData data, string userId, string sessionId,
            string webServerSign1, string webServerSign2, string siteUrl, bool useProxy = false,
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36")
        {
            data.Logger.LogHeader();
            await CheckBalance(data);

            var response = await data.Providers.Captcha.SolveKeyCaptchaAsync(userId, sessionId, webServerSign1, webServerSign2, siteUrl,
                SetupProxy(data, useProxy, userAgent), data.CancellationToken);

            AddCaptchaId(data, response.Id, CaptchaType.KeyCaptcha);
            data.Logger.Log($"Got solution: {response.Response}", LogColors.ElectricBlue);
            return response.Response;
        }

        [Block("Solves a GeeTest captcha",
            extraInfo = "The response will be a list and its elements are (in order) challenge, validate, seccode")]
        public static async Task<List<string>> SolveGeeTestCaptcha(BotData data, string gt, string apiChallenge,
            string apiServer, string siteUrl, bool useProxy = false,
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36")
        {
            data.Logger.LogHeader();
            await CheckBalance(data);

            var response = await data.Providers.Captcha.SolveGeeTestAsync(gt, apiChallenge, apiServer, siteUrl,
                SetupProxy(data, useProxy, userAgent), data.CancellationToken);

            AddCaptchaId(data, response.Id, CaptchaType.GeeTest);
            data.Logger.Log($"Got solution!", LogColors.ElectricBlue);
            data.Logger.Log($"Challenge: {response.Challenge}", LogColors.ElectricBlue);
            data.Logger.Log($"Validate: {response.Validate}", LogColors.ElectricBlue);
            data.Logger.Log($"SecCode: {response.SecCode}", LogColors.ElectricBlue);
            return new List<string> { response.Challenge, response.Validate, response.SecCode };
        }

        [Block("Reports an incorrectly solved captcha to the service in order to get funds back")]
        public static async Task ReportLastSolution(BotData data)
        {
            var id = (long)data.Objects["lastCaptchaId"];
            var type = (CaptchaType)data.Objects["lastCaptchaType"];

            data.Logger.LogHeader();

            try
            {
                await data.Providers.Captcha.ReportSolution(id, type, false, data.CancellationToken);
                data.Logger.Log($"Solution of task {id} reported correctly!", LogColors.ElectricBlue);
            }
            catch (Exception ex)
            {
                data.Logger.Log($"Could not report the solution of task {id} to the service: {ex.Message}", LogColors.ElectricBlue);
            }
        }

        private static async Task CheckBalance(BotData data)
        {
            if (!data.Providers.Captcha.CheckBalanceBeforeSolving)
                return;

            try
            {
                data.CaptchaCredit = await data.Providers.Captcha.GetBalanceAsync(data.CancellationToken);
                data.Logger.Log($"[{data.Providers.Captcha.ServiceType}] Balance: ${data.CaptchaCredit}", LogColors.ElectricBlue);

                if (data.CaptchaCredit < (decimal)0.002)
                    throw new Exception("The remaining balance is too low!");
            }
            catch (Exception ex) // This unwraps aggregate exceptions
            {
                if (ex is AggregateException) throw ex.InnerException;
                else throw;
            }
        }

        private static void AddCaptchaId(BotData data, long id, CaptchaType type)
        {
            data.Objects["lastCaptchaId"] = id;
            data.Objects["lastCaptchaType"] = type;
        }

        private static Proxy SetupProxy(BotData data, bool useProxy, string userAgent)
        {
            return data.UseProxy && useProxy
                ? new Proxy
                {
                    Host = data.Proxy.Host,
                    Port = data.Proxy.Port,
                    Type = Enum.Parse<ProxyType>(data.Proxy.Type.ToString(), true),
                    Username = data.Proxy.Username,
                    Password = data.Proxy.Password,
                    UserAgent = userAgent,
                    Cookies = data.COOKIES
                        .Select(c => (c.Key, c.Value)).ToArray()
                }
                : null;
        }
    }
}
