using System;
using System.Collections.Generic;
using System.Text;

namespace Evernote.Abstractions.Constants
{
    public class ConstText
    {
        public class ClientMessageCenter
        {
            public const string NavigationPushMessage = nameof(NavigationPushMessage);
            public const string NavigationCoursePushMessage = nameof(NavigationCoursePushMessage);
            public const string NavigationDairyPushMessage = nameof(NavigationDairyPushMessage);

            public const string NavigationPopMessage = nameof(NavigationPopMessage);
            public const string NavigationCoursePopMessage = nameof(NavigationCoursePopMessage);
            public const string NavigationDairyPopMessage = nameof(NavigationDairyPopMessage);

            public const string DialogAlertMessage = nameof(DialogAlertMessage);
            public const string DialogSheetMessage = nameof(DialogSheetMessage);
            public const string DialogQuestionMessage = nameof(DialogQuestionMessage);
            public const string DialogEntryMessage = nameof(DialogEntryMessage);
            public const string DialogShowLoadingMessage = nameof(DialogShowLoadingMessage);
            public const string DialogHideLoadingMessage = nameof(DialogHideLoadingMessage);
            public const string DialogToastMessage = nameof(DialogToastMessage);
        }
    }
}
