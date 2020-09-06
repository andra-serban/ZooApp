// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

namespace SampleXamarin
{
    public static class AccountDetails
    {
        /// <summary>
        /// The Azure Spatial Anchors account identifier.
        /// </summary>
        /// <remarks>
        /// Set this to your account id found in the Azure Portal.
        /// </remarks>
        public const string SpatialAnchorsAccountId = "fa1917e0-321c-427c-a95f-43cc32c32950";

        /// <summary>
        /// The Azure Spatial Anchors account key.
        /// Set this to your account id found in the Azure Portal.
        /// </summary>
        /// <remarks>
        /// Set this to your account key found in the Azure Portal.
        /// </remarks>
        public const string SpatialAnchorsAccountKey = "Gg4cVd24I5rUy8y6grCoYSke+wgeVwos7p4QXvftObg=";

        /// <summary>
        /// The Azure Spatial Anchors account domain.
        /// Set this to your account domain found in the Azure Portal.
        /// </summary>
        /// <remarks>
        /// Set this to your account domain found in the Azure Portal.
        /// </remarks>
        public const string SpatialAnchorsAccountDomain = "westeurope.mixedreality.azure.com";

        /// <summary>
        /// The full URL endpoint of the anchor sharing service.
        /// </summary>
        /// <remarks>
        /// Set this to your URL created when publishing your anchor sharing service in the Sharing sample.
        /// It should end in '/api/anchors'.
        /// </remarks>
        public const string AnchorSharingServiceUrl = "https://zooanchors.azurewebsites.net/api/anchors";
    }
}

