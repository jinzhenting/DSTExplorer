namespace DSTExplorer
{
    public static class CorelDraw
    {
        /// <summary>
        /// EMF转PLT
        /// </summary>
        /// <param name="emfPath">EMF位置</param>
        /// <param name="pltPath">PLT位置</param>
        public static void Emf2Plt(string emfPath, string pltPath)
        {
            Corel.Interop.CorelDRAW.Application coreldraw = new Corel.Interop.CorelDRAW.Application();
            coreldraw.OpenDocument(emfPath,1);
            coreldraw.ActiveDocument.ExportBitmap(
                pltPath,
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
