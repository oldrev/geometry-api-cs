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
	internal class OperatorDifferenceCursor : com.epl.geometry.GeometryCursor
	{
		internal com.epl.geometry.GeometryCursor m_inputGeoms;

		internal com.epl.geometry.ProgressTracker m_progress_tracker;

		internal com.epl.geometry.SpatialReference m_Spatial_reference;

		internal com.epl.geometry.Geometry m_geomSubtractor;

		internal int m_index;

		internal bool m_bEmpty;

		internal OperatorDifferenceCursor(com.epl.geometry.GeometryCursor inputGeoms, com.epl.geometry.GeometryCursor geomSubtractor, com.epl.geometry.SpatialReference sr, com.epl.geometry.ProgressTracker progress_tracker)
		{
			m_bEmpty = (geomSubtractor == null);
			m_index = -1;
			m_inputGeoms = inputGeoms;
			m_Spatial_reference = sr;
			m_geomSubtractor = geomSubtractor.Next();
			m_progress_tracker = progress_tracker;
		}

		public override com.epl.geometry.Geometry Next()
		{
			if (m_bEmpty)
			{
				return null;
			}
			com.epl.geometry.Geometry geom;
			if ((geom = m_inputGeoms.Next()) != null)
			{
				m_index = m_inputGeoms.GetGeometryID();
				return com.epl.geometry.OperatorDifferenceLocal.Difference(geom, m_geomSubtractor, m_Spatial_reference, m_progress_tracker);
			}
			return null;
		}

		public override int GetGeometryID()
		{
			return m_index;
		}
	}
}
