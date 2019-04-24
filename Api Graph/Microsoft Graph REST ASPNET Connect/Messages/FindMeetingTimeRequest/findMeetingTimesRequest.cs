using System;
using System.Collections.Generic;

namespace Microsoft_Graph_REST_ASPNET_Connect.Models.Messages.FindMeetingTimeRequest
{
    public class FindMeetingTimesRequest
    {
        public List<Attendee> attendees { get; set; }
        public TimeConstraint timeConstraint { get; set; }
        public string meetingDuration { get; set; }
        public bool returnSuggestionReasons { get; set; }
        public bool isOrganizerOptional { get; set; }
        public int maxCandidates { get; set; }
        //public LocationConstraint locationConstraint { get; set; }
    }

    public class LocationConstraint
    {
        public bool isRequired { get; set; }
        public bool suggestLocation { get; set; }
        public List<locationConstraintItem> locations { get; set; }

    }

    public class locationConstraintItem
    {
        public bool resolveAvailability { get; set; }
        public physicalAddress address { get; set; }
        public string displayName { get; set; }
        public string locationEmailAddress { get; set; }
    }

    public class physicalAddress
    {
        public string city { get; set; }
        public string countryOrRegion { get; set; }
        public string postalCode { get; set; }
        public string state { get; set; }
        public string street { get; set; }
    }

    public class EmailAddress
    {
        public string address { get; set; }
        public string name { get; set; }
    }

    public class Attendee
    {
        public EmailAddress emailAddress { get; set; }
        public string type { get; set; }
    }

    public class Start
    {
        public DateTime dateTime { get; set; }
        public string timeZone { get; set; }
    }

    public class End
    {
        public DateTime dateTime { get; set; }
        public string timeZone { get; set; }
    }

    public class Timeslot
    {
        public Start start { get; set; }
        public End end { get; set; }
    }

    public class TimeConstraint
    {
        public List<Timeslot> timeslots { get; set; }
    }
}