namespace Unit06.Game.Casting
{
    /// <summary>
    /// A label to be displayed.
    /// </summary>
    public class PopUpLabel : Label
    {
        private int textMargin;

        private Image backgroundImage;

        /// <summary>
        /// Constructs a new instance of a Pop Up Label.
        /// </summary>
        public PopUpLabel(Text text, Point position, int textMargin, Image backgroundImage) : base(text, position)
        {
            this.textMargin = textMargin;
            this.backgroundImage = backgroundImage;
        }

        public Image GetBackgroundImage()
        {
            return backgroundImage;
        }
        public Point GetBackgroundPosition()
        {
            return base.GetPosition();
        }
        public override Point GetPosition()
        {
            return base.GetPosition().Add(new Point(textMargin, textMargin));
        }
    }
}