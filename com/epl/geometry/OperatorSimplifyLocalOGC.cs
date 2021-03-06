/*
Copyright 2017 Echo Park Labs

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

For additional information, contact:

email: info@echoparklabs.io
*/


namespace com.epl.geometry
{
	internal class OperatorSimplifyLocalOGC : com.epl.geometry.OperatorSimplifyOGC
	{
		public override com.epl.geometry.GeometryCursor Execute(com.epl.geometry.GeometryCursor geoms, com.epl.geometry.SpatialReference spatialRef, bool bForceSimplify, com.epl.geometry.ProgressTracker progressTracker)
		{
			return new com.epl.geometry.OperatorSimplifyCursorOGC(geoms, spatialRef, bForceSimplify, progressTracker);
		}

		public override bool IsSimpleOGC(com.epl.geometry.Geometry geom, com.epl.geometry.SpatialReference spatialRef, bool bForceTest, com.epl.geometry.NonSimpleResult result, com.epl.geometry.ProgressTracker progressTracker)
		{
			int res = com.epl.geometry.OperatorSimplifyLocalHelper.IsSimpleOGC(geom, spatialRef, bForceTest, result, progressTracker);
			return res > 0;
		}

		public override com.epl.geometry.Geometry Execute(com.epl.geometry.Geometry geom, com.epl.geometry.SpatialReference spatialRef, bool bForceSimplify, com.epl.geometry.ProgressTracker progressTracker)
		{
			com.epl.geometry.SimpleGeometryCursor inputCursor = new com.epl.geometry.SimpleGeometryCursor(geom);
			com.epl.geometry.GeometryCursor outputCursor = Execute(inputCursor, spatialRef, bForceSimplify, progressTracker);
			return outputCursor.Next();
		}
	}
}
