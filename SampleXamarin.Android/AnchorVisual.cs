﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using Android.Content;
using Android.Views;
using Google.AR.Core;
using Google.AR.Sceneform;
using Google.AR.Sceneform.Math;
using Google.AR.Sceneform.Rendering;
using Google.AR.Sceneform.UX;
using Java.Util.Concurrent;
using Microsoft.Azure.SpatialAnchors;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using static Android.Views.View;

namespace SampleXamarin
{
    internal class AnchorVisual
    {
        public string identifier;
        public enum NamedShape
        {
            Sphere,
            Cube,
            Cylinder,
        }

        private TransformableNode transformableNode;
        private NamedShape shape = NamedShape.Sphere;
        private Material material;

        private static Dictionary<int, CompletableFuture> solidColorMaterialCache = new Dictionary<int, CompletableFuture>();
        Context context;
        public AnchorVisual(ArFragment arFragment, Anchor localAnchor)
        {
            AnchorNode = new AnchorNode(localAnchor);

            transformableNode = new TransformableNode(arFragment.TransformationSystem);
            transformableNode.ScaleController.Enabled = false;
            transformableNode.TranslationController.Enabled = false;
            transformableNode.RotationController.Enabled = false;
            transformableNode.SetParent(AnchorNode);
        }
        public AnchorVisual(ArFragment arFragment, Anchor localAnchor, Context context)
        {
            AnchorNode = new AnchorNode(localAnchor);

            transformableNode = new TransformableNode(arFragment.TransformationSystem);
            transformableNode.ScaleController.Enabled = false;
            transformableNode.TranslationController.Enabled = false;
            transformableNode.RotationController.Enabled = false;
            transformableNode.SetParent(AnchorNode);
            this.context = context;
        }
        public AnchorVisual(ArFragment arFragment, CloudSpatialAnchor cloudAnchor)
            : this(arFragment, cloudAnchor.LocalAnchor)
        {
            CloudAnchor = cloudAnchor;
        }

        public AnchorVisual(ArFragment arFragment, CloudSpatialAnchor cloudAnchor, Context context)
            : this(arFragment, cloudAnchor.LocalAnchor)
        {
            CloudAnchor = cloudAnchor;
            this.context = context;
        }

        public AnchorNode AnchorNode { get; }

        public CloudSpatialAnchor CloudAnchor { get; set; }

        public Anchor LocalAnchor => this.AnchorNode.Anchor;

        public NamedShape Shape
        {
            get { return shape; }
            set
            {
                if (shape != value)
                {
                    shape = value;
                    MainThread.BeginInvokeOnMainThread(RecreateRenderableOnMainThread);
                }
            }
        }

        public bool IsMovable
        {
            set
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    transformableNode.TranslationController.Enabled = value;
                    transformableNode.RotationController.Enabled = value;
                });
            }
        }

        public void AddToScene(ArFragment arFragment)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                RecreateRenderableOnMainThread();
                AnchorNode.SetParent(arFragment.ArSceneView.Scene);
            });
        }

        public void SetColor(Context context, int rgb)
        {
            lock (this)
            {
                if (!solidColorMaterialCache.ContainsKey(rgb))
                {
                    solidColorMaterialCache[rgb] = MaterialFactory.MakeOpaqueWithColor(context, new Color(rgb));
                }
                CompletableFuture loadMaterial = solidColorMaterialCache[rgb];
                loadMaterial.ThenAccept(new FutureResultConsumer<Material>(SetMaterial));
            }
        }

        public void SetMaterial(Material material)
        {
            if (this.material != material)
            {
                this.material = material;
                MainThread.BeginInvokeOnMainThread(RecreateRenderableOnMainThread);
            }
        }

        public void SetIdentifier(string identifier)
        {
            this.identifier = identifier;
        }

        public void Destroy()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                AnchorNode.Renderable = null;
                AnchorNode.SetParent(null);
                Anchor localAnchor = AnchorNode.Anchor;
                if (localAnchor != null)
                {
                    AnchorNode.Anchor = null;
                    localAnchor.Detach();
                }
            });
        }

        private void RecreateRenderableOnMainThread()
        {
            if (material != null)
            {
                Renderable renderable;
                switch (shape)
                {
                    case NamedShape.Sphere:
                        renderable = ShapeFactory.MakeSphere(
                                0.1f,
                                new Vector3(0.0f, 0.1f, 0.0f),
                                material);
                        break;
                    case NamedShape.Cube:
                        renderable = ShapeFactory.MakeCube(
                                new Vector3(0.161f, 0.161f, 0.161f),
                                new Vector3(0.0f, 0.0805f, 0.0f),
                                material);
                        break;
                    case NamedShape.Cylinder:
                        renderable = ShapeFactory.MakeCylinder(
                                0.0874f,
                                0.175f,
                                new Vector3(0.0f, 0.0875f, 0.0f),
                                material);
                        break;
                    default:
                        throw new InvalidOperationException("Invalid shape");
                }
                transformableNode.Renderable = renderable;
                transformableNode.SetOnTouchListener(new AnchorTouchListener(context, this.identifier));
            }
        }
    }       
}