﻿using static Report.API.Helper.Enums;

namespace Report.API.Dtos
{
    public class ContactInfoDto
    {
        public InfoType InfoType { get; set; }
        public string InfoContent { get; set; }

    }
}
