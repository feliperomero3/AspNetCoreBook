﻿using AngleSharp.Html.Dom;

namespace SportsStore.IntegrationTests.Helpers;

public static class HttpClientExtensions
{
    public static Task<HttpResponseMessage> SendAsync(
        this HttpClient client,
        IHtmlFormElement form,
        IHtmlElement submitButton,
        IEnumerable<KeyValuePair<string, string>> formValues)
    {
        foreach (var kvp in formValues)
        {
            if (form[kvp.Key] is IHtmlInputElement inputElement)
            {
                inputElement.Value = kvp.Value;
            }
            else if (form[kvp.Key] is IHtmlSelectElement selectElement)
            {
                selectElement.Value = kvp.Value;
            }
            else if (form[kvp.Key] is IHtmlTextAreaElement textAreaElement)
            {
                textAreaElement.Value = kvp.Value;
            }
        }

        var submit = form.GetSubmission() ?? throw new InvalidOperationException("submitting the form returned null.");
        var target = (Uri)submit.Target;

        if (submitButton.HasAttribute("formaction"))
        {
            var formaction = submitButton.GetAttribute("formaction");
            target = new Uri(formaction!, UriKind.Relative);
        }

        var submission = new HttpRequestMessage(new HttpMethod(submit.Method.ToString()), target)
        {
            Content = new StreamContent(submit.Body)
        };

        foreach (var header in submit.Headers)
        {
            submission.Headers.TryAddWithoutValidation(header.Key, header.Value);
            submission.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }

        return client.SendAsync(submission);
    }

    public static Task<HttpResponseMessage> SendAsync(
        this HttpClient client,
        IHtmlFormElement form,
        IHtmlElement submitButton)
    {
        return SendAsync(client, form, submitButton, new Dictionary<string, string> { });
    }

}
