using UnityEngine.UIElements;

namespace Jobus.Extensions
{
    public static class UIToolkitExtensions
    {
        /// <summary>
        /// Set display mode of the element. Equivalent of 'element.style.display = DisplayStyle.Flex/None', but also sends an ElementActiveEvent event.
        /// </summary>
        public static void SetActive(this VisualElement element, bool active)
        {
            if (IsActive(element) == active)
                return;
    
            element.style.display = active ? DisplayStyle.Flex : DisplayStyle.None;
    
            using (var e = ElementActiveEvent.GetPooled(active))
            {
                e.target = element;
                element.SendEvent(e);
            }
        }
    
        /// <summary>
        /// Get display mode of the element. Equivalent of checking 'element.style.display != DisplayStyle.None'.
        /// </summary>
        public static bool IsActive(this VisualElement element)
        {
            return element.style.display.value != DisplayStyle.None;
        }
    
        /// <summary>
        /// Returns root parent of the element. Returns self if element has no parent.
        /// </summary>
        public static VisualElement GetRoot(this VisualElement ele)
        {
            return ele.parent == null ? ele : ele.parent.GetRoot();
        }
    }
    
    /// <summary>
    /// Sent by the VisualElement.SetActive() extension to allow for listening for the event where an element is toggled on or off.
    /// </summary>
    public class ElementActiveEvent : EventBase<ElementActiveEvent>
    {
        public bool active;
    
        protected override void Init()
        {
            base.Init();
    
            active = false;
        }
    
        public static ElementActiveEvent GetPooled(bool active)
        {
            var e = GetPooled();
            e.active = active;
            return e;
        }
    }
}