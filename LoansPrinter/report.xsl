<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:l="http://schemas.datacontract.org/2004/07/Ploeh.Samples.Loan"
                xmlns:d2p1="http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                xmlns:i="http://www.w3.org/2001/XMLSchema-instance"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                version="1.0">
  <xsl:output method="text" />
	
  <xsl:template match="l:CompositeMortgageApplicationProcessor">- Do all of this:<xsl:apply-templates select="l:Nodes" /></xsl:template>

  <!--Templates for specific concrete mortgage application processors-->
  <xsl:template match="*[@i:type = 'DateAndLocationMortgageApplicationProcessor']">- **Print** date and location</xsl:template>

  <xsl:template match="*[@i:type = 'GreetingMortgageApplicationProcessor']">- **Print** greeting</xsl:template>

  <xsl:template match="*[@i:type = 'ApplicationDetailsHeadlineMortgageApplicationProcessor']">- **Print** *Application details* headline</xsl:template>

  <xsl:template match="*[@i:type = 'PrimaryApplicantMortgageApplicationProcessor']">- **Print** details about primary applicant</xsl:template>

  <xsl:template match="*[@i:type = 'AdditionalApplicantsMortgageApplicationProcessor']">- **Print** details about all additional applicants</xsl:template>

  <xsl:template match="*[@i:type = 'FinancingHeadlineMortgageApplicationProcessor']">- **Print** *Financing* headline</xsl:template>

  <xsl:template match="*[@i:type = 'SelfPaymentMortgageApplicationProcessor']">- **Print** self payment amount</xsl:template>

  <xsl:template match="*[@i:type = 'CurrentPropertyMortgageApplicationProcessor']">- **Print** information about current property</xsl:template>

  <xsl:template match="*[@i:type = 'PropertyHeadlineMortgageApplicationProcessor']">- **Print** "Property" headline</xsl:template>

  <xsl:template match="*[@i:type = 'PropertyMortgageApplicationProcessor']">- **Print** details about the target property</xsl:template>

  <xsl:template match="*[@i:type = 'DesiredLoanMortgageApplicationProcessor']">- **Print** headline and introduction of the mortgage loan offer</xsl:template>

  <xsl:template match="*[@i:type = 'OfferIntroductionMortgageApplicationProcessor']">- **Print** details about the desired mortgage loan structure</xsl:template>

  <xsl:template match="*[@i:type = 'FixedRateAnnuityOfferMortgageApplicationProcessor']">- **Print** an offer of a fixed rate annuity loan</xsl:template>

  <xsl:template match="*[@i:type = 'AdjustableRateAnnuityOfferMortgageApplicationProcessor']">- **Print** an offer of a adjustable rate annuity loan</xsl:template>

  <xsl:template match="*[@i:type = 'InterestOnlyOfferMortgageApplicationProcessor']">- **Print** an offer of an interest only loan</xsl:template>

  <xsl:template match="*[@i:type = 'RealtyUpsellMortgageApplicationProcessor']">- **Print** an offer of additional real estate services</xsl:template>

  <!--Templates for specific concrete mortgage application specifications-->
  <xsl:template match="*[@i:type = 'AndMortgageApplicationSpecification']">- all of this is true:<xsl:apply-templates select="l:Specifications" /></xsl:template>
  
  <xsl:template match="*[@i:type = 'AnyAdditionalApplicantsSpecification']">- there are additional applicants</xsl:template>

  <xsl:template match="*[@i:type = 'CurrentPropertyExistsSpecification']">- applicant currently owns a property</xsl:template>

  <xsl:template match="*[@i:type = 'CurrentPropertySoldAsFinancingMortgageApplicationSpecification']">- applicant will sell current property to finance new property</xsl:template>

  <xsl:template match="*[@i:type = 'DesiredLoanTypeMortgageApplicationSpecification']">- the desired loan type is <xsl:value-of select="l:MatchingLoanType" /></xsl:template>

  <!--Template for conditional evaluation (if)-->
  <xsl:template match="*[@i:type = 'ConditionalMortgageApplicationProcessor']">- **If**
      <xsl:apply-templates select="l:Specification" /> **then**
      <xsl:apply-templates select="l:TruthProcessor" />
  </xsl:template>
</xsl:stylesheet>