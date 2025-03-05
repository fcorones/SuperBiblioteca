namespace Biblioteca_Blazor_v1.Client.wwwroot.js
{
    public class infiniteScroll
    {
        window.initInfiniteScroll = (dotNetHelper) => {
            let observer = new IntersectionObserver((entries) => {
                if (entries[0].isIntersecting) {
                    dotNetHelper.invokeMethodAsync('CargarMasLibros');
                }
            }, { rootMargin: "100px" });

            let trigger = document.getElementById('loadMoreTrigger');
            if (trigger) {
                observer.observe(trigger);
            }
        };

    }
}
