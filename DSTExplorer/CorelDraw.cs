namespace DSTExplorer
{
    public static class CorelDraw
    {
        /// <summary>
        /// EMF转PLT
        /// </summary>
        /// <param name="emf_path">EMF位置</param>
        /// <param name="plt_path">PLT位置</param>
        public static void Emf2Plt(string emf_path, string plt_path)
        {
            Corel.Interop.CorelDRAW.Application coreldraw = new Corel.Interop.CorelDRAW.Application();
            coreldraw.OpenDocument(emf_path,1);
            coreldraw.ActiveDocument.ExportBitmap(
                plt_path,
                Corel.Interop.VGCore.cdrFilter.cdrPLT,
                Corel.Interop.VGCore.cdrExportRange.cdrCurrentPage,
                Corel.Interop.VGCore.cdrImageType.cdrRGBColorImage,
                0, 0, 72, 72,
                Corel.Interop.VGCore.cdrAntiAliasingType.cdrNoAntiAliasing,
                false,
                true,
                true,
                false,
                Corel.Interop.VGCore.cdrCompressionType.cdrCompressionNone, null
                ).Finish();
            coreldraw.ActiveDocument.Close();
            coreldraw.Quit();
        }
    }
}
