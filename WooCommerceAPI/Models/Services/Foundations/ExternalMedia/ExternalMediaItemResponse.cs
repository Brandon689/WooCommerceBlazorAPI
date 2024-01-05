using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalMedia
{

    internal class ExternalMediaItemResponse
    {
        [JsonProperty("id")]
        internal int Id { get; set; } = 0;

        internal DateTime date { get; set; }
        internal DateTime date_gmt { get; set; }

        [JsonProperty("guid")]
        internal Guid Guid { get; set; }
        internal DateTime modified { get; set; }
        internal DateTime modified_gmt { get; set; }
        [JsonProperty("slug")]
        internal string slug { get; set; }
        internal string status { get; set; }
        internal string type { get; set; }
        internal string link { get; set; }
        [JsonProperty("title")]
        internal Title Title { get; set; }
        internal int author { get; set; }
        internal string comment_status { get; set; }
        internal string ping_status { get; set; }
        internal string template { get; set; }
        internal List<object> meta { get; set; }
        internal string permalink_template { get; set; }
        internal string generated_slug { get; set; }
        internal Description description { get; set; }
        internal Caption caption { get; set; }
        internal string alt_text { get; set; }
        internal string media_type { get; set; }
        internal string mime_type { get; set; }
        internal MediaDetails media_details { get; set; }
        internal object post { get; set; }
        internal string source_url { get; set; }
        internal List<string> missing_image_sizes { get; set; }
        internal Links _links { get; set; }
    }


    internal class About
    {
        internal string href { get; set; }
    }

    internal class Author
    {
        internal bool embeddable { get; set; }
        internal string href { get; set; }
    }

    internal class Caption
    {
        internal string raw { get; set; }
        internal string rendered { get; set; }
    }

    internal class Collection
    {
        internal string href { get; set; }
    }

    internal class Cury
    {
        internal string name { get; set; }
        internal string href { get; set; }
        internal bool templated { get; set; }
    }

    internal class Description
    {
        internal string raw { get; set; }
        internal string rendered { get; set; }
    }

    internal class Full
    {
        internal string file { get; set; }
        internal int width { get; set; }
        internal int height { get; set; }
        internal string mime_type { get; set; }
        internal string source_url { get; set; }
    }

    internal class Guid
    {
        [JsonProperty("rendered")]
        internal string rendered { get; set; }
        [JsonProperty("raw")]

        internal string raw { get; set; }
    }

    internal class ImageMeta
    {
        internal string aperture { get; set; }
        internal string credit { get; set; }
        internal string camera { get; set; }
        internal string caption { get; set; }
        internal string created_timestamp { get; set; }
        internal string copyright { get; set; }
        internal string focal_length { get; set; }
        internal string iso { get; set; }
        internal string shutter_speed { get; set; }
        internal string title { get; set; }
        internal string orientation { get; set; }
        internal List<object> keywords { get; set; }
    }

    internal class Links
    {
        internal List<Self> self { get; set; }
        internal List<Collection> collection { get; set; }
        internal List<About> about { get; set; }
        internal List<Author> author { get; set; }
        internal List<Reply> replies { get; set; }

        [JsonProperty("wp:action-unfiltered-html")]
        internal List<WpActionUnfilteredHtml> wpactionunfilteredhtml { get; set; }

        [JsonProperty("wp:action-assign-author")]
        internal List<WpActionAssignAuthor> wpactionassignauthor { get; set; }
        internal List<Cury> curies { get; set; }
    }

    internal class MediaDetails
    {
        internal int width { get; set; }
        internal int height { get; set; }
        internal string file { get; set; }
        internal int filesize { get; set; }
        internal Sizes sizes { get; set; }
        internal ImageMeta image_meta { get; set; }
    }

    internal class Reply
    {
        internal bool embeddable { get; set; }
        internal string href { get; set; }
    }

    internal class Self
    {
        internal string href { get; set; }
    }

    internal class Sizes
    {
        internal WoocommerceThumbnail woocommerce_thumbnail { get; set; }
        internal Full full { get; set; }
    }

    internal class Title
    {
        [JsonProperty("raw")]

        internal string Raw { get; set; }
        [JsonProperty("rendered")]

        internal string Rendered { get; set; }
    }

    internal class WoocommerceThumbnail
    {
        internal string file { get; set; }
        internal int width { get; set; }
        internal int height { get; set; }
        internal int filesize { get; set; }
        internal bool uncropped { get; set; }
        internal string mime_type { get; set; }
        internal string source_url { get; set; }
    }

    internal class WpActionAssignAuthor
    {
        internal string href { get; set; }
    }

    internal class WpActionUnfilteredHtml
    {
        internal string href { get; set; }
    }





}
